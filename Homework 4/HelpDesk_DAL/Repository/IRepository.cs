﻿using HelpDesk_DomainModel.Models;
using System.Linq.Expressions;

namespace HelpDesk_DAL.Repository
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity Create(TEntity entity);

        // insert or update to be added

        /// <summary>
        /// The entity must be FOUND in the DB first
        /// </summary>
        TEntity Delete(TEntity entity);

        /// <summary>
        /// Query for Updatable (Tracked) entities
        /// </summary>
        IQueryable<TEntity> AsQueryable();

        /// <summary>
        /// Query for read-only (Untracked) entities
        /// </summary>
        IQueryable<TEntity> AsReadOnlyQueryable();

        TEntity InsertOrUpdate(
            Expression<Func<TEntity, bool>> predicate,
            TEntity entity
        );
    }
}
