using Moryx.StateMachines;

namespace MyApplication.Resources
{
    internal class SpecificState : SomeStateBase
    {
        public SpecificState(SomeCell context, StateMap stateMap) : base(context, stateMap)
        {
        }
    }
}
