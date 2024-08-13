using Moryx.StateMachines;

namespace MyApplication.Resources.SomeCell.States
{
    internal class SpecificState : SomeStateBase
    {
        public SpecificState(SomeCell context, StateMap stateMap) : base(context, stateMap)
        {
        }
    }
}
