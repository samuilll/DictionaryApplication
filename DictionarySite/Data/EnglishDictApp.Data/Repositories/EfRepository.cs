namespace EnglishDictApp.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using EnglishDictApp.Data.Common.Repositories;

    using Microsoft.EntityFrameworkCore;

    public class EfRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public EfRepository(ApplicationDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.DbSet = this.Context.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet { get; set; }

        protected ApplicationDbContext Context { get; set; }

        public virtual IQueryable<TEntity> All() => this.DbSet;

        public virtual IQueryable<TEntity> AllAsNoTracking() => this.DbSet.AsNoTracking();

        public virtual Task<TEntity> GetByIdAsync(params object[] id) => this.DbSet.FindAsync(id);

        public virtual async Task Add(TEntity entity)
        {
            this.DbSet.Add(entity);
            await this.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;

            this.Context.Update(entity);

            await this.SaveChangesAsync();
        }

        public virtual void Delete(TEntity entity)
        {
            this.DbSet.Remove(entity);
        }

        public async Task<int> SaveChangesAsync() => await this.Context.SaveChangesAsync();

        public void Dispose() => this.Context.Dispose();
    }
}
