using System;
using System.Threading.Tasks;
using Common.Core.Contracts.Interfaces.Base;

namespace Common.SF.Infrastructure.EntityFramework.Interfaces
{
    public interface IRepository : IReadOnlyRepository
    {
        Task Create<TEntity>(TEntity entity, Guid createdBy = new Guid()) where TEntity : class, IEntity;
        Task Update<TEntity>(TEntity entity, Guid modifiedBy = new Guid()) where TEntity : class, IEntity;
        Task Delete<TEntity>(object id) where TEntity : class, IEntity;
        Task Delete<TEntity>(TEntity entity) where TEntity : class, IEntity;
        void Save();
        Task SaveAsync();
        Task SetDBConnection(Guid configurationSettingID);
        Task SetDefaultDBConnection();
        Task InitializeReferences();
    }
}
