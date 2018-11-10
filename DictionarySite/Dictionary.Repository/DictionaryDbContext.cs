using Dictionary.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dictionary.Repository
{
    public class DictionaryDbContext : IdentityDbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Word> Words { get; set; }

        public DbSet<UsersWords> UsersWords { get; set; }

        public DictionaryDbContext()
        {
            
        }

        public DictionaryDbContext(DbContextOptions<DictionaryDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(
                    @"Server=(LocalDb)\MSSQLLocalDB;Database = DictionaryDb;Trusted_Connection = True;");
            }
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UsersWords>(e =>
            {
                e.HasOne(uw => uw.User)
                    .WithMany(u => u.UserWords)
                    .HasForeignKey(uw => uw.UserId);

                e.HasOne(uw => uw.Word)
                    .WithMany(w => w.WordUsers)
                    .HasForeignKey(uw => uw.WordId);

                e.HasKey(uw => new {uw.UserId, uw.WordId});
            });
            base.OnModelCreating(builder);
        }
    }
}
