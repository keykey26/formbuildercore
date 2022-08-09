using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FormBuilder.Models
{
    public class FormAttributesModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(Form))
            {
                return new FormAttributeBinder();
            }

            // else...
            return null;
        }
    }

    public class FormAttributeBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(Form))
            {
                var name = bindingContext.ValueProvider.GetValue("Name").FirstValue;

                if (!string.IsNullOrWhiteSpace(name))
                {
                    Form element = new Form
                    {
                        Name = name,
                        Attributes = new List<FormAttribute>()
                    };

                    int i = 0;

                    while (bindingContext.ValueProvider.GetValue("[" + i + "].Name").FirstValue != null)
                    {
                        var type = bindingContext.ValueProvider.GetValue("[" + i + "].Type").FirstValue;
                        var attribute = Activator.CreateInstance(Type.GetType("NCVODMM.Models." + type)) as FormAttribute;

                        var props = attribute.GetType().GetProperties();

                        foreach (var prop in props)
                        {
                            if (prop.PropertyType.Name.Equals("String"))
                            {
                                prop.SetValue(attribute, bindingContext.ValueProvider.GetValue("[" + i + "]." + prop.Name).FirstValue);
                                continue;
                            }

                            attribute.SetValue(bindingContext.ValueProvider.GetValue("[" + i + "]." + prop.Name));
                        }

                        element.Attributes.Add(attribute);

                        i++;
                    }

                    bindingContext.Result = ModelBindingResult.Success(element);
                }
            }
        }
    }
}
