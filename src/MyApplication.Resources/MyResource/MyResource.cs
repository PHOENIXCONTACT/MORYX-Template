using System.ComponentModel;
using System.Runtime.Serialization;
using Moryx.AbstractionLayer.Resources;
using Moryx.Serialization;

namespace MyApplication.Resources.MyResource;

[ResourceRegistration] // Only necessary for dependency injection like logging or parallel operations
public class MyResource : Resource
{
    protected override void OnInitialize()
    {
        base.OnInitialize();
    }

    protected override void OnDispose()
    {
        base.OnDispose();
    }
}
