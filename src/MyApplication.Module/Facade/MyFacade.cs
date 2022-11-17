using System;
using Moryx.Runtime.Modules;
using MyApplication.Module.Components;

namespace MyApplication.Module.Facade
{
    public class MyFacade : IFacadeControl, IMyFacade
    {
        public IMyComponent Component { get; set; }

        public void Activate()
        {
        }

        public void Deactivate()
        {
        }

        public Action ValidateHealthState { get; set; }
    }
}