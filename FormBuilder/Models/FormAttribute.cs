using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FormBuilder.Models
{
    public interface FormAttribute
    {
        string Name { get; set; }
        string Type { get; set; }
        string Label { get; set; }
        string Placeholder { get; set; }
        string Value { get; set; }

        void SetValue(ValueProviderResult value);
    }
}
