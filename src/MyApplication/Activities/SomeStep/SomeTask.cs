// Copyright (c) 2025, Phoenix Contact GmbH & Co. KG
// Licensed under the Apache License, Version 2.0

using Moryx.AbstractionLayer.Workplans;
using System.ComponentModel.DataAnnotations;

namespace MyApplication.Activities.SomeStep;

[Display(Name = "Some Task", Description = "Task which does something with a product")]
public class SomeTask : TaskStep<SomeActivity, SomeParameters>
{
}
