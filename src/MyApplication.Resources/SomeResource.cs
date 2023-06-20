using System.ComponentModel;
using System.Runtime.Serialization;
using Moryx.AbstractionLayer.Resources;
using Moryx.Serialization;
using MyApplication.Capabilities;

namespace MyApplication.Resources
{
    [ResourceRegistration] // Only necessary for dependency injection like logging or parallel operations
    public class SomeResource : PublicResource, ISomeResource
    {
        [DataMember, EntrySerialize]
        [Description("Configured value for the capabilities")]
        public int Value { get; set; }

        [ResourceReference(ResourceRelationType.Extension)]
        public MyResource Reference { get; set; }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            Capabilities = new SomeCapabilities{Value = Value};
        }
    }
}