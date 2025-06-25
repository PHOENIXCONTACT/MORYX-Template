// Copyright (c) 2025, Phoenix Contact GmbH & Co. KG

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using Moryx.AbstractionLayer;
using Moryx.AbstractionLayer.Drivers.InOut;
using Moryx.AbstractionLayer.Resources;
using Moryx.ControlSystem.Activities;
using Moryx.ControlSystem.Cells;
using Moryx.ControlSystem.VisualInstructions;
using Moryx.Serialization;
using MyApplication.Activities.SomeStep;
using MyApplication.Capabilities;

namespace MyApplication.Resources;

[ResourceRegistration] // Only necessary for dependency injection like logging or parallel operations
public class SomeCell : Cell
{
    private Session _currentSession;
    private long _currentInstruction;

    [ResourceReference(ResourceRelationType.Driver)]
    public IInOutDriver<object, object> Driver { get; set; }

    [ResourceReference(ResourceRelationType.Extension)]
    public IVisualInstructor VisualInstructor { get; set; }

    [DataMember, EntrySerialize]
    [Description("Configured value for the capabilities")]
    public int Value { get; set; }

    protected override void OnInitialize()
    {
        base.OnInitialize();
        Capabilities = new SomeCapabilities { Value = Value };

        if (Driver != null)
            Driver.Input.InputChanged += OnInputChanged;
    }

    protected override void OnStart()
    {
        base.OnStart();
    }

    protected override void OnStop()
    {
        base.OnStop();
    }

    protected override void OnDispose()
    {
        base.OnDispose();
    }

    public override IEnumerable<Session> ControlSystemAttached()
    {
        yield break;
    }

    public override IEnumerable<Session> ControlSystemDetached()
    {
        yield break;
    }

    public override void StartActivity(ActivityStart activityStart)
    {
        /* Start execution here */
    }

    private void InstructionCompleted(int result, ActivityStart session)
    {
    }

    public override void ProcessAborting(IActivity affectedActivity)
    {
        // Default behavior: Clear instruction and abort execution
        if (_currentSession is ActivityStart activityStart)
        {
            // Clear driver and/or instructor
            VisualInstructor?.Clear(_currentInstruction);
            if (Driver != null)
                Driver.Output["Start"] = false;

            // Report current activity as failed
            activityStart.CreateResult((int)SomeActivityResults.Failed);
        }
    }

    public override void SequenceCompleted(SequenceCompleted completed)
    {
    }

    private void OnInputChanged(object sender, InputChangedEventArgs args)
    {
        if (args.Key == "Ready" /* Driver indicates ready */)
        {
            var rtw = Session.StartSession(ActivityClassification.Production, ReadyToWorkType.Pull);
            _currentSession = rtw;
            PublishReadyToWork(rtw);
        }
        else if (args.Key == "Completed" && _currentSession is ActivityStart activitySession)
        {
            var result = activitySession.CreateResult(0);
            _currentSession = result;
            PublishActivityCompleted(result);
        }
    }
}
