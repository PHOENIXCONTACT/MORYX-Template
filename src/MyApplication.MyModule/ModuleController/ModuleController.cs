using System.ComponentModel;
using Microsoft.Extensions.Logging;
using Moryx.Configuration;
using Moryx.Container;
using Moryx.Runtime.Container;
using Moryx.Runtime.Modules;
using MyApplication.MyModule.Components;
using MyApplication.MyModule.Facade;

namespace MyApplication.MyModule.ModuleController
{
    [Description("Description of MyModule")]
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

        /// <summary>
        /// Create a new instance of the module
        /// </summary>
        public ModuleController(IModuleContainerFactory containerFactory, IConfigManager configManager, ILoggerFactory loggerFactory) 
            : base(containerFactory, configManager, loggerFactory)
        {
        }

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