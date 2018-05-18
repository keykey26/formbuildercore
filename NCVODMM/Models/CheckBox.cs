using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace NCVODMM.Models
{
    public class CheckBox : FormAttribute
    {
	    public string Name { get; set; }
	    public string Type { get; set; }
	    public string Label { get; set; }
	    public string Placeholder { get; set; }
	    public string Value { get; set; }
		public bool BoolVal { get; set; }

	    public void SetValue(ValueProviderResult value)
	    {
		    Value = value.FirstValue;
	    }
	}
}
