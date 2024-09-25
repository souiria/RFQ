using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Core.Settings;
using Common.Core.Infrastructure.Helpers;
using Common.SF.Contracts.Interfaces.Base.Base64;
using Common.SF.Contracts.Interfaces.Core;
using Common.SF.Contracts.Interfaces.Core.Settings;
using Common.SF.Infrastructure.EntityFramework.Interfaces;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Newtonsoft.Json;

namespace Common.SF.Infrastructure.EntityFramework
{
    public class Repository : ReadOnlyRepository, IRepository
    {
        private const string _dbConnectionDefault = DefaultConnectionStringHelper.DefaultConnectionString;

        private IUtilities _utilityProxy { get; set; }
        private IH1ConfigurationSetting _h1ConfigurationSetting { get; set; }

        public Repository(DbContext context) : base(context)
        {
            Initialize();
            context.Database.CommandTimeout = 600;
        }

        private void Initialize()
        {
            _utilityProxy = ServiceProxy.Create<IUtilities>(new Uri("fabric:/Core.Framework/SF.Core.Utilities"));
            _h1ConfigurationSetting = ServiceProxy.Create<IH1ConfigurationSetting>(_utilityProxy.InitializeH1ConfigurationSetting().GetAwaiter().GetResult(), new ServicePartitionKey(0));
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

        public async Task SetDBConnection(Guid configurationSettingID)
        {
            var dbConnection = _dbConnectionDefault;
            //Commented by amit
            //var connectionList = (await _h1ConfigurationSetting.GetAll()).Where(it => it.H1ConfigurationKeyGuid == configurationSettingID);
            var settings = JsonConvert.DeserializeObject<IEnumerable<H1ConfigurationSettingModel>>((await ((IBase64)_h1ConfigurationSetting)?.GetAll()).DecompressBase64());

            var connectionList = settings.Where(it => it.Id == configurationSettingID);
            if (connectionList.Any())
            {
                var connection = connectionList.FirstOrDefault();

                if (!connection.IsEncrypted)
                    dbConnection = connection.H1ConfigParameterValue;
                else
                    dbConnection = await _utilityProxy.Decrypt(connection.H1ConfigParameterValue, true, connection.H1EncryptionKey);
            }

            //if (context.Database.Connection.State == System.Data.ConnectionState.Closed)
            //{
                this.context.Database.Connection.ConnectionString = dbConnection;
            //}
            //else if (context.Database.Connection.ConnectionString != dbConnection)
            //{                
            //    this.context.Database.Connection.ConnectionString = dbConnection;
            //}
        }

        public async Task SetDefaultDBConnection()
        {
            this.context.Database.Connection.ConnectionString = _dbConnectionDefault;
        }
        /// <summary>
        /// Initilize all references for the repository
        /// </summary>
        public async Task InitializeReferences()
        {
            _utilityProxy = ServiceProxy.Create<IUtilities>(new Uri("fabric:/Core.Framework/SF.Core.Utilities"));
            _h1ConfigurationSetting = ServiceProxy.Create<IH1ConfigurationSetting>(await _utilityProxy.InitializeH1ConfigurationSetting(), new ServicePartitionKey(0));
        }
    }
}
