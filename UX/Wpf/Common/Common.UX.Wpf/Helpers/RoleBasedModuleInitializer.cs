using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using Common.Core.Contracts.Models.Administration.Security;
using Common.UX.Wpf.Attributes;
using Common.UX.Wpf.Contracts.Models;
using Microsoft.Practices.ServiceLocation;
using Prism.Logging;
using Prism.Modularity;

namespace Common.UX.Wpf.Helpers
{
    public class RoleBasedModuleInitializer : IModuleInitializer
    {
        private readonly IServiceLocator serviceLocator;
        private readonly ILoggerFacade loggerFacade;
        private List<IModule> modules = new List<IModule>();
        private bool wizardLaunched = false;
        protected StatusBarMessageHelper _statusMessage;

        public Exception exceptionThrown { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="ModuleInitializer"/>.
        /// </summary>
        /// <param name="serviceLocator">The container that will be used to resolve the modules by specifying its type.</param>
        /// <param name="loggerFacade">The logger to use.</param>
        public RoleBasedModuleInitializer(IServiceLocator serviceLocator, ILoggerFacade loggerFacade)
        {
            this.serviceLocator = serviceLocator ?? throw new ArgumentNullException(nameof(serviceLocator));
            this.loggerFacade = loggerFacade ?? throw new ArgumentNullException(nameof(loggerFacade));            
        }

        /// <summary>
        /// Initializes the specified module.
        /// </summary>
        /// <param name="moduleInfo">The module to initialize</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Catches Exception to handle any exception thrown during the initialization process with the HandleModuleInitializationError method.")]
        public void Initialize(ModuleInfo moduleInfo)
        {
            if (moduleInfo == null)
                throw new ArgumentNullException(nameof(moduleInfo));

            IModule moduleInstance = null;
            try
            {
                switch (moduleInfo.ModuleName)
                {
                    case ("StartupWizard, v1.0.0.0"):
                        if (exceptionThrown == null && StartupHelper.GetLaunchStatusTask.Result != LaunchStatus.Completed)
                        {
                            moduleInstance = InitializeModule(moduleInfo);
                            wizardLaunched = true;
                        }
                        break;

                    case ("Themes, v1.0.0.0"):
                        moduleInstance = InitializeModule(moduleInfo);
                        break;

                    case ("ErrorWindow, v1.0.0.0"):
                        if (exceptionThrown != null)
                        {
                            moduleInstance = InitializeModule(moduleInfo);

                        }
                        break;

                    default:
                        if (!wizardLaunched && exceptionThrown == null)
                            moduleInstance = InitializeModule(moduleInfo);
                        break;
                }
            }
            catch (Exception ex)
            {
                //this.HandleModuleInitializationError(
                //    moduleInfo,
                //    moduleInstance != null ? moduleInstance.GetType().Assembly.FullName : null,
                //    ex);
                exceptionThrown = ex;
            }
        }

        private IModule InitializeModule(ModuleInfo moduleInfo)
        {
            var moduleInstance = this.CreateModule(moduleInfo);
            if (moduleInstance != null)
                moduleInstance.Initialize();
            return moduleInstance;
        }

        private bool ModuleIsInUserRole(ModuleInfo moduleInfo)
        {
            var isInRole = false;
            try
            {
                var roles = GetModuleRoles(moduleInfo);
                foreach (var role in roles)
                {
                    if (WindowsPrincipal.Current.IsInRole(role))
                    {
                        isInRole = true;
                        break;
                    }
                }
                return isInRole;
            }
            catch (Exception ex)
            {
                _statusMessage.DisplayMessage($"Module import failed for: {moduleInfo.ModuleName}, with the Exception: {ex.Message}. Please contact the IT Helpdesk", "Module Import", UXNotificationType.ErrorMessage);

                return isInRole;
            }
            
        }

        private IEnumerable<string> GetModuleRoles(ModuleInfo moduleInfo)
        {
            var type = Type.GetType(moduleInfo.ModuleType);
            foreach (var attribute in GetCustomAttribute<RolesAttribute>(type))
            {
                return attribute.Roles.AsEnumerable();
            }
            return null;
        }

        IEnumerable<T> GetCustomAttribute<T>(Type type)
        {
            return type.GetCustomAttributes(typeof(T), true).OfType<T>();
        }

        /// <summary>
        /// Handles any exception occurred in the module Initialization process,
        /// logs the error using the <see cref="ILoggerFacade"/> and throws a <see cref="ModuleInitializeException"/>.
        /// This method can be overridden to provide a different behavior.
        /// </summary>
        /// <param name="moduleInfo">The module metadata where the error happenened.</param>
        /// <param name="assemblyName">The assembly name.</param>
        /// <param name="exception">The exception thrown that is the cause of the current error.</param>
        /// <exception cref="ModuleInitializeException"></exception>
        public virtual void HandleModuleInitializationError(ModuleInfo moduleInfo, string assemblyName, Exception exception)
        {
            if (moduleInfo == null)
                throw new ArgumentNullException(nameof(moduleInfo), exceptionThrown);

            if (exception == null)
                throw new ArgumentNullException(nameof(exception), exceptionThrown);

            Exception moduleException;

            if (exception is ModuleInitializeException)
            {
                moduleException = exception;
            }
            else
            {
                if (!string.IsNullOrEmpty(assemblyName))
                {
                    moduleException = new ModuleInitializeException(moduleInfo.ModuleName, assemblyName, exception.Message, exception);
                }
                else
                {
                    moduleException = new ModuleInitializeException(moduleInfo.ModuleName, exception.Message, exception);
                }
            }

            this.loggerFacade.Log(moduleException.ToString(), Category.Exception, Priority.High);

            throw moduleException;
        }

        /// <summary>
        /// Uses the container to resolve a new <see cref="IModule"/> by specifying its <see cref="Type"/>.
        /// </summary>
        /// <param name="moduleInfo">The module to create.</param>
        /// <returns>A new instance of the module specified by <paramref name="moduleInfo"/>.</returns>
        protected virtual IModule CreateModule(ModuleInfo moduleInfo)
        {
            if (moduleInfo == null)
                throw new ArgumentNullException(nameof(moduleInfo));

            return this.CreateModule(moduleInfo.ModuleType);
        }

        /// <summary>
        /// Uses the container to resolve a new <see cref="IModule"/> by specifying its <see cref="Type"/>.
        /// </summary>
        /// <param name="typeName">The type name to resolve. This type must implement <see cref="IModule"/>.</param>
        /// <returns>A new instance of <paramref name="typeName"/>.</returns>
        protected virtual IModule CreateModule(string typeName)
        {
            Type moduleType = Type.GetType(typeName);
            return (IModule)this.serviceLocator.GetInstance(moduleType);
        }

        public void AddModuleInfo(IEnumerable<ModuleInfo> moduleInfos)
        {
            Sort(moduleInfos.ToList());
            foreach (var moduleInfo in moduleInfos)
            {
                modules.Add(CreateModule(moduleInfo));
            }
        }

        public List<ModuleInfo> Sort(List<ModuleInfo> moduleInfos)
        {
            foreach (var module in moduleInfos)
            {
                module.State = ModuleState.Initializing;
            }
            moduleInfos.Sort((x, y) =>
            {
                var type = Type.GetType(x.ModuleType);
                var attribute = GetCustomAttribute<ModulePriorityAttribute>(type).FirstOrDefault();
                var xPriority = (attribute != null) ? attribute.Priority : 0;
                attribute = GetCustomAttribute<ModulePriorityAttribute>(type).FirstOrDefault();
                var yPriority = (attribute != null) ? attribute.Priority : 0;
                if (xPriority > yPriority)
                    return -1;
                else if (yPriority > xPriority)
                    return 1;
                else
                    return 0;
            });
            return moduleInfos;
        }

        public void InitializeAll()
        {
            //TODO: Implement
        }
    }
}