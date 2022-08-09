using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FormBuilder.Models
{
    public class TextType : FormAttribute
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }
        public string Placeholder { get; set; }
        public string Value { get; set; }

        public void SetValue(ValueProviderResult value)
        {
        }
    }
}
