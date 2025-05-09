using Moryx.AbstractionLayer;
using Moryx.AbstractionLayer.Recipes;
using Moryx.ControlSystem.VisualInstructions;
using Moryx.Serialization;

namespace MyApplication.Activities.SomeStep;

public class SomeParameters : VisualInstructionParameters
{
    protected override void Populate(IProcess process, Parameters instance)
    {
    }
}
