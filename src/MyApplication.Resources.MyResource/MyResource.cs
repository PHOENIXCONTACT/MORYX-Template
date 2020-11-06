using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Moryx.AbstractionLayer.Resources;
using Moryx.Serialization;

namespace MyApplication.Resources.MyResource
{
    public class MyResource : Resource
    {
        [DataMember, EntrySerialize]
        public int Number { get; set; }

        [EntrySerialize, DisplayName("Do Foo")]
        public void DoFoo()
        {
        }
    }
}
