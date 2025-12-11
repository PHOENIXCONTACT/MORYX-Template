// Copyright (c) 2025, Phoenix Contact GmbH & Co. KG
// Licensed under the Apache License, Version 2.0

using Moryx.AbstractionLayer.Activities;
using Moryx.ControlSystem.Simulation;
using Moryx.Drivers.Simulation.InOutDriver;

namespace MyApplication.Resources;

public class SomeSimulatedInOutDriver : SimulatedInOutDriver
{
    public override void Ready(Activity activity)
    {
        SimulatedState = SimulationState.Requested;

        SimulatedInput.Values["Ready"] = true;
        SimulatedInput.RaiseInputChanged("Ready");
    }

    protected override void OnOutputSet(object sender, string key)
    {
        if (key == "Start")
        {
            if ((bool)SimulatedOutput.Values["Start"])
            {
                SimulatedState = SimulationState.Executing;
            }
            else
            {
                SimulatedState = SimulationState.Idle;
            }
        }
    }

    public override void Result(SimulationResult result)
    {
        SimulatedInput.Values["Completed"] = true;
        SimulatedInput.RaiseInputChanged("Completed");
    }
}
