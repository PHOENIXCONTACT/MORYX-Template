using System.ComponentModel.DataAnnotations;

namespace MyApplication.Activities.SomeStep;

public enum SomeActivityResults
{
    [Display(Name = "Success")]
    Success,

    Failed
}