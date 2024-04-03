using System.ComponentModel;
using System.Runtime.Serialization;
using Moryx.AbstractionLayer.Resources;
using Moryx.Serialization;

namespace MyApplication.Resources;

public class MyResource : Resource
{
    [DataMember, EntrySerialize]
    public int Number { get; set; }

    [EntrySerialize, DisplayName("Do Foo")]
    public void DoFoo()
    {
    }
}
