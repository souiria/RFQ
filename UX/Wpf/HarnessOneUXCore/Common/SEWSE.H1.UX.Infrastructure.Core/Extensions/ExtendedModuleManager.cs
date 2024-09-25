using Prism.Logging;
using Prism.Modularity;
using SEWSE.H1.UX.Infrastructure.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEWSE.H1.UX.Infrastructure.Core.Extensions
{
    public class ExtendedModuleManager : IModuleManager
    {
        IModuleCatalog moduleCatalog;
        IModuleInitializer moduleInitializer;
        ILoggerFacade loggerFacade;
        private IEnumerable<IModuleTypeLoader> typeLoaders;
        private HashSet<IModuleTypeLoader> subscribedToModuleTypeLoaders = new HashSet<IModuleTypeLoader>();

        public virtual IEnumerable<IModuleTypeLoader> ModuleTypeLoaders
        {
            get
            {
                if (this.typeLoaders == null)
                {
                    this.typeLoaders = new List<IModuleTypeLoader>
                                          {
                                              new FileModuleTypeLoader()
                                          };
                }

                return this.typeLoaders;
            }

            set
            {
                this.typeLoaders = value;
            }
        }


        public ExtendedModuleManager(IModuleInitializer moduleInitializer, IModuleCatalog moduleCatalog, ILoggerFacade loggerFacade)
        {
            if (moduleInitializer == null)
                throw new ArgumentNullException(nameof(moduleInitializer));

            if (moduleCatalog == null)
                throw new ArgumentNullException(nameof(moduleCatalog));

            if (loggerFacade == null)
                throw new ArgumentNullException(nameof(loggerFacade));

            this.moduleInitializer = moduleInitializer;
            this.moduleCatalog = moduleCatalog;
            this.loggerFacade = loggerFacade;
        }

        public event EventHandler<ModuleDownloadProgressChangedEventArgs> ModuleDownloadProgressChanged;
        public event EventHandler<LoadModuleCompletedEventArgs> LoadModuleCompleted;

        public void LoadModule(string moduleName)
        {
            IEnumerable<ModuleInfo> module = this.moduleCatalog.Modules.Where(m => m.ModuleName == moduleName);
            if (module == null || module.Count() != 1)
            {
                throw new Exception();
            }

            IEnumerable<ModuleInfo> modulesToLoad = this.moduleCatalog.CompleteListWithDependencies(module);

            this.LoadModuleTypes(modulesToLoad);
        }

        private void RaiseLoadModuleCompleted(ModuleInfo moduleInfo, Exception error)
        {
            this.RaiseLoadModuleCompleted(new LoadModuleCompletedEventArgs(moduleInfo, error));
        }

        private void RaiseLoadModuleCompleted(LoadModuleCompletedEventArgs e)
        {
            if (this.LoadModuleCompleted != null)
            {
                this.LoadModuleCompleted(this, e);
            }
        }

        public void Run()
        {
            this.moduleCatalog.Initialize();

            this.LoadModulesWhenAvailable();
        }

        private void LoadModulesWhenAvailable()
        {
            IEnumerable<ModuleInfo> whenAvailableModules = this.moduleCatalog.Modules.Where(m => m.InitializationMode == InitializationMode.WhenAvailable);
            IEnumerable<ModuleInfo> modulesToLoadTypes = this.moduleCatalog.CompleteListWithDependencies(whenAvailableModules);
            if (modulesToLoadTypes != null)
            {
                this.LoadModuleTypes(modulesToLoadTypes);
            }
        }

        private void LoadModuleTypes(IEnumerable<ModuleInfo> moduleInfos)
        {
            if (moduleInfos == null)
            {
                return;
            }
            var notStartedModules = moduleInfos.Where((x) => x.State == ModuleState.NotStarted);
            BeginRetrievingAll(notStartedModules);
            //foreach (ModuleInfo moduleInfo in moduleInfos)
            //{
            //    if (moduleInfo.State == ModuleState.NotStarted)
            //    {
            //        if (this.ModuleNeedsRetrieval(moduleInfo))
            //        {
            //            this.BeginRetrievingModule(moduleInfo);
            //        }
            //        else
            //        {
            //            moduleInfo.State = ModuleState.ReadyForInitialization;
            //        }
            //    }
            //}

            this.LoadModulesThatAreReadyForLoad();
        }

        protected virtual bool ModuleNeedsRetrieval(ModuleInfo moduleInfo)
        {
            if (moduleInfo == null)
                throw new ArgumentNullException(nameof(moduleInfo));

            if (moduleInfo.State == ModuleState.NotStarted)
            {
                // If we can instantiate the type, that means the module's assembly is already loaded into
                // the AppDomain and we don't need to retrieve it.
                bool isAvailable = Type.GetType(moduleInfo.ModuleType) != null;
                if (isAvailable)
                {
                    moduleInfo.State = ModuleState.ReadyForInitialization;
                }

                return !isAvailable;
            }

            return false;
        }

        private void BeginRetrievingModule(ModuleInfo moduleInfo)
        {
            ModuleInfo moduleInfoToLoadType = moduleInfo;
            IModuleTypeLoader moduleTypeLoader = this.GetTypeLoaderForModule(moduleInfoToLoadType);
            moduleInfoToLoadType.State = ModuleState.LoadingTypes;

            // Delegate += works differently betweem SL and WPF.
            // We only want to subscribe to each instance once.
            if (!this.subscribedToModuleTypeLoaders.Contains(moduleTypeLoader))
            {
                moduleTypeLoader.ModuleDownloadProgressChanged += this.IModuleTypeLoader_ModuleDownloadProgressChanged;
                moduleTypeLoader.LoadModuleCompleted += this.IModuleTypeLoader_LoadModuleCompleted;
                this.subscribedToModuleTypeLoaders.Add(moduleTypeLoader);
            }

            moduleTypeLoader.LoadModuleType(moduleInfo);
        }

        private void BeginRetrievingAll(IEnumerable<ModuleInfo> moduleInfos)
        {
            foreach (var moduleInfo in moduleInfos)
            {
                IModuleTypeLoader moduleTypeLoader = this.GetTypeLoaderForModule(moduleInfo);
                moduleInfo.State = ModuleState.LoadingTypes;

                // Delegate += works differently betweem SL and WPF.
                // We only want to subscribe to each instance once.
                if (!this.subscribedToModuleTypeLoaders.Contains(moduleTypeLoader))
                {
                    moduleTypeLoader.ModuleDownloadProgressChanged += this.IModuleTypeLoader_ModuleDownloadProgressChanged;
                    moduleTypeLoader.LoadModuleCompleted += this.IModuleTypeLoader_LoadModuleCompleted;
                    this.subscribedToModuleTypeLoaders.Add(moduleTypeLoader);
                }

                moduleTypeLoader.LoadModuleType(moduleInfo);
            }
            LoadModulesThatAreReadyForLoad();
        }

        private void IModuleTypeLoader_ModuleDownloadProgressChanged(object sender, ModuleDownloadProgressChangedEventArgs e)
        {
            this.RaiseModuleDownloadProgressChanged(e);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1")]
        protected virtual void HandleModuleTypeLoadingError(ModuleInfo moduleInfo, Exception exception)
        {
            if (moduleInfo == null)
                throw new ArgumentNullException(nameof(moduleInfo));

            ModuleTypeLoadingException moduleTypeLoadingException = exception as ModuleTypeLoadingException;

            if (moduleTypeLoadingException == null)
            {
                moduleTypeLoadingException = new ModuleTypeLoadingException(moduleInfo.ModuleName, exception.Message, exception);
            }

            this.loggerFacade.Log(moduleTypeLoadingException.Message, Category.Exception, Priority.High);

            throw moduleTypeLoadingException;
        }

        private bool AreDependenciesLoaded(ModuleInfo moduleInfo)
        {
            IEnumerable<ModuleInfo> requiredModules = this.moduleCatalog.GetDependentModules(moduleInfo);
            if (requiredModules == null)
            {
                return true;
            }

            int notReadyRequiredModuleCount =
                requiredModules.Count(requiredModule => requiredModule.State != ModuleState.Initialized);

            return notReadyRequiredModuleCount == 0;
        }

        private IModuleTypeLoader GetTypeLoaderForModule(ModuleInfo moduleInfo)
        {
            foreach (IModuleTypeLoader typeLoader in this.ModuleTypeLoaders)
            {
                if (typeLoader.CanLoadModuleType(moduleInfo))
                {
                    return typeLoader;
                }
            }
            throw new Exception();
        }

        private void InitializeModule(ModuleInfo moduleInfo)
        {
            if (moduleInfo.State == ModuleState.Initializing)
            {
                this.moduleInitializer.Initialize(moduleInfo);
                moduleInfo.State = ModuleState.Initialized;
                this.RaiseLoadModuleCompleted(moduleInfo, null);
            }
        }

        protected void LoadModulesThatAreReadyForLoad()
        {
            bool keepLoading = true;
            while (keepLoading)
            {
                keepLoading = false;
                IEnumerable<ModuleInfo> availableModules = this.moduleCatalog.Modules.Where(m => m.State == ModuleState.ReadyForInitialization);
                availableModules = SortByPriority(availableModules);
                foreach (ModuleInfo moduleInfo in availableModules)
                {
                    if ((moduleInfo.State != ModuleState.Initialized) && (this.AreDependenciesLoaded(moduleInfo)))
                    {
                        moduleInfo.State = ModuleState.Initializing;
                        this.InitializeModule(moduleInfo);
                        keepLoading = true;
                        break;
                    }
                }
            }
        }

        private IEnumerable<ModuleInfo> SortByPriority(IEnumerable<ModuleInfo> availableModules)
        {
            var list = availableModules.ToList();
            list.Sort((x, y) =>
            {
                var type = Type.GetType(x.ModuleType);
                var attribute = GetCustomAttribute<ModulePriorityAttribute>(type).FirstOrDefault();
                var xPriority = (attribute != null) ? attribute.Priority : 0;
                type = Type.GetType(y.ModuleType);
                attribute = GetCustomAttribute<ModulePriorityAttribute>(type).FirstOrDefault();
                var yPriority = (attribute != null) ? attribute.Priority : 0;
                if (xPriority > yPriority)
                    return -1;
                else if (yPriority > xPriority)
                    return 1;
                else
                    return 0;
            });
            return list;
        }
        IEnumerable<T> GetCustomAttribute<T>(Type type)
        {
            return type.GetCustomAttributes(typeof(T), true).OfType<T>();
        }

        private void IModuleTypeLoader_LoadModuleCompleted(object sender, LoadModuleCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if ((e.ModuleInfo.State != ModuleState.Initializing) && (e.ModuleInfo.State != ModuleState.Initialized))
                {
                    e.ModuleInfo.State = ModuleState.ReadyForInitialization;
                }

                // This callback may call back on the UI thread, but we are not guaranteeing it.
                // If you were to add a custom retriever that retrieved in the background, you
                // would need to consider dispatching to the UI thread.
                //this.LoadModulesThatAreReadyForLoad();
            }
            else
            {
                this.RaiseLoadModuleCompleted(e);

                // If the error is not handled then I log it and raise an exception.
                if (!e.IsErrorHandled)
                {
                    this.HandleModuleTypeLoadingError(e.ModuleInfo, e.Error);
                }
            }
        }

        private void RaiseModuleDownloadProgressChanged(ModuleDownloadProgressChangedEventArgs e)
        {
            if (this.ModuleDownloadProgressChanged != null)
            {
                this.ModuleDownloadProgressChanged(this, e);
            }
        }
    }
}
