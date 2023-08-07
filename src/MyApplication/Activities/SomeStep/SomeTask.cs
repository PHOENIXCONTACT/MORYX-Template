using Moryx.AbstractionLayer;
using System.ComponentModel.DataAnnotations;

namespace MyApplication.Activities.SomeStep
{
    [Display(Name = "Some Task", Description = "Task which does something with a product")]
    public class SomeTask : TaskStep<SomeActivity, SomeParameters>
    {
    }
}