﻿namespace EnglishDictApp.Data.Common.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;

    using EnglishDictApp.Data.Common.Models;

    public interface IDeletableEntityRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IDeletableEntity
    {
        IQueryable<TEntity> AllWithDeleted();

        IQueryable<TEntity> AllAsNoTrackingWithDeleted();

        Task<TEntity> GetByIdWithDeletedAsync(params object[] id);

        void HardDelete(TEntity entity);

        Task Undelete(TEntity entity);
    }
}
