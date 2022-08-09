using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormBuilder;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FormBuilder.Models
{
    public class Form
    {

        public string Name { get; set; }

        [JsonProperty(ItemConverterType = typeof(FormAttributeTypeJsonConverter))]
        public List<FormAttribute> Attributes { get; set; }

    }
}
