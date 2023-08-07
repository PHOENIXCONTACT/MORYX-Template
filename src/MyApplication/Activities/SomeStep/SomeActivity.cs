using Moryx.AbstractionLayer;
using Moryx.AbstractionLayer.Capabilities;
using MyApplication.Capabilities;

namespace MyApplication.Activities.SomeStep
{
    [ActivityResults(typeof(SomeActivityResults))]
    public class SomeActivity : Activity<SomeParameters>
    {
        public override ProcessRequirement ProcessRequirement => ProcessRequirement.NotRequired;

        public override ICapabilities RequiredCapabilities => new SomeCapabilities();

        protected override ActivityResult CreateResult(long resultNumber)
        {
            return ActivityResult.Create((SomeActivityResults)resultNumber);
        }

        protected override ActivityResult CreateFailureResult()
        {
            return ActivityResult.Create(SomeActivityResults.Failed);
        }
    }
}