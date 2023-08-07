using System;
using Moryx.AbstractionLayer.Recipes;
using Moryx.Container;
using Moryx.ControlSystem.Setups;
using Moryx.Modules;
using Moryx.Workplans;
using MyApplication.Capabilities;

namespace MyApplication.ControlSystem.SetupTriggers
{
    [ExpectedConfig(typeof(MySetupTriggerConfig))]
    [Plugin(LifeCycle.Transient, typeof(ISetupTrigger), Name = nameof(MySetupTrigger))]
    public class MySetupTrigger : SetupTriggerBase<MySetupTriggerConfig>
    {
        public override SetupExecution Execution => SetupExecution.BeforeProduction; // SetupExecution.AfterProduction

        public override SetupEvaluation Evaluate(IProductRecipe recipe)
        {
            return true;
            return SetupClassification.MaterialChange;
            return SetupEvaluation.Provide(new SomeCapabilities());
        }

        public override IWorkplanStep CreateStep(IProductRecipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}