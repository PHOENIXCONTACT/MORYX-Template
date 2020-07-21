using Moryx.Runtime.Container;
using Moryx.Runtime.Modules;
using MyApplication.Facade;
using MyApplication.Module.Components;
using MyApplication.Module.Facade;
using MyApplication.Plugins;

namespace MyApplication.Module.ModuleController
{
    [ServerModule(ModuleName)]
    //public class ModuleController : ServerModuleBase<ModuleConfig> // No facade export
    public class ModuleController : ServerModuleFacadeControllerBase<ModuleConfig>, IFacadeContainer<IMyFacade> // Facade export
    {
        internal const string ModuleName = "MyModule";

        public override string Name => ModuleName;

        // Import a data model
        //[Named(SomeConstants.Namespace)]
        //public IUnitOfWorkFactory MyModel { get; set; }

        // Import a facade, e.g. IResourceManagement
        //[RequiredModuleApi(IsStartDependency = true, IsOptional = false)]
        //public IOtherFacade Dependency { get; set; }

        #region State transition

        /// <summary>
        /// Code executed on start up and after service was stopped and should be started again
        /// </summary>
        protected override void OnInitialize()
        {
            // Register model
            //Container.SetInstance(MyModel);

            // Register required facade
            //Container.SetInstance(Dependency);
            
            // Load plugins
            Container.LoadComponents<IMyModulesPlugin>();
        }

        /// <summary>
        /// Code executed after OnInitialize
        /// </summary>
        protected override void OnStart()
        {
            // Start component
            Container.Resolve<IMyComponent>().Start();

            ActivateFacade(_myFacade);
        }

        /// <summary>
        /// Code executed when service is stopped
        /// </summary>
        protected override void OnStop()
        {
            // Tear down facades
            DeactivateFacade(_myFacade);

            Container.Resolve<IMyComponent>().Stop();
        }

        #endregion

        #region FacadeContainer

        private readonly MyFacade _myFacade = new MyFacade();
        IMyFacade IFacadeContainer<IMyFacade>.Facade => _myFacade;

        #endregion
    }
}