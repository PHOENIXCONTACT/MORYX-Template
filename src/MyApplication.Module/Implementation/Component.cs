using Moryx.Container;
using MyApplication.Module.Components;

namespace MyApplication.Module.Implementation
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