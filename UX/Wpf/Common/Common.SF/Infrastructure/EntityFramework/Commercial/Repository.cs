using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using Common.Core.Contracts.Interfaces.Base;

namespace Common.SF.Infrastructure.EntityFramework.Commercial
{
    public class Repository : ReadOnlyRepository, IRepository
    {
        private const string _dbConnectionDefault = DefaultConnectionStringHelper.DefaultConnectionString;

        public Repository(DbContext context) : base(context)
        {
            context.Database.CommandTimeout = 300;
        }

        public virtual async Task Create<TEntity>(TEntity entity, Guid createdBy = new Guid()) where TEntity : class, IEntity
        {
            entity.CreatedDate = DateTime.UtcNow;
            entity.ModifiedDate = DateTime.UtcNow;
            context.Set<TEntity>().Add(entity);
        }

        public virtual async Task Update<TEntity>(TEntity entity, Guid modifiedBy = new Guid()) where TEntity : class, IEntity
        {
            entity.ModifiedDate = DateTime.UtcNow;
            context.Set<TEntity>().AddOrUpdate(entity);
        }

        public virtual async Task Delete<TEntity>(object id) where TEntity : class, IEntity
        {
            TEntity entity = context.Set<TEntity>().Find(id);
            await Delete(entity);
        }

        public virtual async Task Delete<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            TEntity matchedEntity = context.Set<TEntity>().Find(entity.Id);
            if (matchedEntity != null)
            {
                context.Set<TEntity>().Remove(matchedEntity);
            }
        }

        public virtual void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                ThrowEnhancedValidationException(e);
            }
        }

        public virtual Task SaveAsync()
        {
            try
            {
                return context.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                ThrowEnhancedValidationException(e);
            }

            return Task.FromResult(0);
        }

        protected virtual void ThrowEnhancedValidationException(DbEntityValidationException e)
        {
            var errorMessages = e.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

            var fullErrorMessage = string.Join("; ", errorMessages);
            var exceptionMessage = string.Concat(e.Message, " The validation errors are: ", fullErrorMessage);
            throw new DbEntityValidationException(exceptionMessage, e.EntityValidationErrors);
        }

        public void SetDBConnection(string dbConnection)
        {
            context.Database.Connection.ConnectionString = dbConnection ?? throw new ArgumentNullException($"{nameof(dbConnection)} was null and could not be set");
        }
    }
}
