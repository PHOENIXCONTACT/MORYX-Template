using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Moryx.AbstractionLayer.Resources;

namespace MyApplication.Resources.MyResource
{
    public class MyResource : Resource
    {
        [DataMember, EditorBrowsable]
        public int Number { get; set; }

        [EditorBrowsable, DisplayName("Do Foo")]
        public void DoFoo()
        {
        }
    }
}
