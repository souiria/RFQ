using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Common.Core.Contracts.Interfaces.Base;
using Common.SF.Infrastructure.EntityFramework.Interfaces;

namespace Common.SF.Infrastructure.EntityFramework
{
    public class EntityFrameworkRepository<T> where T : class, IEntity
    {
        private readonly IRepository _repository;

        public EntityFrameworkRepository()
        {
            _repository = new Repository(new Entities());
        }

        public Task<T> CreateEntity(T entity)
        {
            try
            {
                _repository.Create(entity);
                _repository.Save();                            
                return Task.FromResult<T>(entity);
            }
            catch (Exception ex)
            {

            }
            return Task.FromResult<T>(entity);
        }

        public Task<T> UpdateEntity(T entity)
        {
            try
            {
                _repository.Update(entity);
                _repository.Save();
                return Task.FromResult<T>(entity);
            }
            catch (Exception ex)
            {
            }
            return Task.FromResult<T>(entity);
        }

        public Task<List<T>> GetEntity(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool asNoTracking = false)
        {
            try
            {
                var result = _repository.Get(filter, orderBy, includeProperties, skip, take, asNoTracking);
                return Task.FromResult(result.ToList());
            }
            catch (Exception ex)
            {
                //TODO: Handle exceptions
                throw ex;
            }
        }

        public Task<List<T>> GetAllEntities(
              Expression<Func<T, bool>> filter = null,
              Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
              string includeProperties = null,
              int? skip = null,
              int? take = null,
              bool asNoTracking = false)
        {
            try
            {
                var result = _repository.GetAll(orderBy, includeProperties, skip, take, asNoTracking);
                return Task.FromResult(result.ToList());
            }
            catch (Exception ex)
            {
                //TODO: Handle exceptions
                throw ex;
            }
        }

        public Task<T> GetFirstEntity(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool asNoTracking = false)
        {
            try
            {
                var result = _repository.GetFirst(filter, orderBy, includeProperties);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                //TODO: Handle exceptions
            }

            return Task.FromResult<T>(null);
        }

        public Task<T> DeleteEntity(T entity)
        {
            try
            {
                _repository.Delete(entity);
                _repository.Save();
                return Task.FromResult(entity);
            }
            catch (Exception Ex)
            {
                //TODO: Handle exceptions
            }
            return Task.FromResult(entity);
        }

        public async Task SetDBConnection(Guid confugurationSettingID)
        {
            await _repository.SetDBConnection(confugurationSettingID);
        }
        public async Task SetDefaultDBConnection()
        {
            await _repository.SetDefaultDBConnection();
        }

        public async Task<IEnumerable<T>> ExecuteSQLQuery(string storedProcedure, SqlParameter parameter)
        {
            return await _repository.ExecuteSQLQuery<T>(storedProcedure, parameter);
        }
        public async Task<IEnumerable<T>> ExecuteSQLQuery(string storedProcedure, params SqlParameter[] parameter)
        {
            return await _repository.ExecuteSQLQuery<T>(storedProcedure, parameter);
        }
        public async Task InitializeReferences()
        {
            await _repository.InitializeReferences();
        }
    }
}
