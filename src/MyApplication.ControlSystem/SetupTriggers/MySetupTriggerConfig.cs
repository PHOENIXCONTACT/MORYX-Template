using Moryx.ControlSystem.Setups;

namespace MyApplication.ControlSystem.SetupTriggers
{
    public class MySetupTriggerConfig : SetupTriggerConfig
    {
        public override string PluginName => nameof(MySetupTrigger);
    }
}