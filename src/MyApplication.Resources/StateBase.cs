using Moryx.StateMachines;

namespace MyApplication.Resources.SomeCell.States
{
    internal abstract class SomeStateBase : StateBase<SomeCell>
    {

        
        public SomeStateBase(SomeCell context, StateMap stateMap) : base(context, stateMap)
        {
        }
    }
}
