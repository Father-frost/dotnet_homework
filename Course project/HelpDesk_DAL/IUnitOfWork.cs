using HelpDesk_DAL.Repository;
using HelpDesk_DomainModel.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace HelpDesk_DAL
{
    public interface IUnitOfWork
    {
        IDbContextTransaction BeginTransaction();

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;

        Task<int> SaveChangesAsync();
    }
}
