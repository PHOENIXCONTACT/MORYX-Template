using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using Moryx.Configuration;
using Moryx.Runtime.Configuration;
using Moryx.Serialization;

namespace MyApplication.MyModule.ModuleController
{
    [DataContract]
    public class ModuleConfig : ConfigBase
    {
        [DataMember, DefaultValue("Some Text")]
        [Description("Text configuration property")]
        public string Text { get; set; }

        [DataMember]
        public float Number { get; set; }

        [DataMember, DefaultValue(42)]
        [PrimitiveValues(3, 7, 10, 42, 1337)]
        [Description("Select number from range of possible numbers")]
        public int LimitedNumber { get; set; }

        [DataMember]
        [Description("Names of team members")]
        public List<string> Team { get; set; }
    }
}