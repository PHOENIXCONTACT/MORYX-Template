// Copyright (c) 2025, Phoenix Contact GmbH & Co. KG

using Moryx.ControlSystem.Setups;

namespace MyApplication.ControlSystem.SetupTriggers;

public class MySetupTriggerConfig : SetupTriggerConfig
{
    public override string PluginName => nameof(MySetupTrigger);
}
