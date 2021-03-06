﻿namespace EnglishDictApp.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using EnglishDictApp.Data.Common.Models;
    using EnglishDictApp.Data.Models;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Setting> Settings { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            ConfigureUserIdentityRelations(builder);

            this.ConfiguringOtherRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private void ConfiguringOtherRelations(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserWord>(e =>
            {
                e.HasOne(uw => uw.User)
                    .WithMany(u => u.UserWords)
                    .HasForeignKey(uw => uw.UserId);

                e.HasOne(uw => uw.Word)
                    .WithMany(w => w.WordUsers)
                    .HasForeignKey(uw => uw.WordId);

                e.ToTable("UsersWords");

                e.HasKey(uw => new { uw.UserId, uw.WordId });
            });

            builder.Entity<Statistic>(e =>
            {
                e.HasKey(st => new { st.UserId, st.WordId, st.ExamId });

                e.HasOne(st => st.User)
                .WithMany(u => u.Statistics)
                .HasForeignKey(st => st.UserId);

                e.HasOne(st => st.Exam)
                .WithMany(ex => ex.Statistics)
                .HasForeignKey(st => st.ExamId);

                e.HasOne(st => st.Word)
                .WithMany(w => w.Statistics)
                .HasForeignKey(st => st.WordId);
            });

            builder.Entity<Word>(e =>
            {
                e.ToTable("Words");

                e.HasIndex(w => w.Title).IsUnique(true);
            });

            builder.Entity<Exam>(e =>
            {
                e.HasOne(ex => ex.User)
                .WithMany(u => u.Exams)
                .HasForeignKey(ex => ex.UserId);

                e.ToTable("Exams");
            });

            builder.Entity<Sentence>(e =>
            {
                e.ToTable("Sentences");
            });

            builder.Entity<WordSentence>(e =>
            {
                e.ToTable("SentencesWords");

                e.HasKey(ws => new { ws.SentenceId, ws.WordId });

                e.HasOne(ws => ws.Sentence)
                .WithMany(s => s.SentenceWords)
                .HasForeignKey(ws => ws.SentenceId);

                e.HasOne(ws => ws.Word)
                .WithMany(w => w.WordSentences)
                .HasForeignKey(ws => ws.WordId);
            });

            builder.Entity<Meaning>(e =>
            {
                e.ToTable("Meanings");

                e.HasOne(m => m.Word)
                .WithMany(w => w.Meanings)
                .HasForeignKey(m => m.WordId);
            });
        }

        private static void ConfigureUserIdentityRelations(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
