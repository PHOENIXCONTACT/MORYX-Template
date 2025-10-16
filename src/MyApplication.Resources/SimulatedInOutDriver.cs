// Copyright (c) 2025, Phoenix Contact GmbH & Co. KG

using Moryx.AbstractionLayer;
using Moryx.ControlSystem.Simulation;
using Moryx.Drivers.Simulation.InOutDriver;

namespace MyApplication.Resources;

public class SimulatedInOutDriver : SimulatedInOutDriver<object, object>
{
    public override void Ready(IActivity activity)
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
