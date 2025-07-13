// Copyright (c) 2025, Phoenix Contact GmbH & Co. KG

using System.ComponentModel.DataAnnotations;

namespace MyApplication.Activities.SomeStep;

public enum SomeActivityResults
{
    [Display(Name = "Success")]
    Success,

    Failed
}
