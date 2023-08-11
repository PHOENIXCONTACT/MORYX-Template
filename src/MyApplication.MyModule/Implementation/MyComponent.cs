using Moryx.Container;
using MyApplication.MyModule.Components;

namespace MyApplication.MyModule.Implementation
{
    [Component(LifeCycle.Singleton, typeof(IMyComponent))]
    public class Component : IMyComponent
    {
        public void Start()
        {
        }

        public void Stop()
        {
        }
    }
}