using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FormBuilder.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FormBuilder.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string jsonForm = @"{
									'Name': 'form',
									'Attributes':
									[
										{'Name': 'text1',
										'Type': 'TextType',
										'Label': 'text 1',
										'Placeholder': 'some text'},
										{'Name': 'text2',
										'Type': 'TextType',
										'Label': 'text 2',
										'Placeholder': 'some text'},
										{'Name': 'check',
										'Type': 'CheckBox',
										'Label': 'check',
										'Placeholder': 'some check test'}	
									]
								}";

            Form form = JsonConvert.DeserializeObject<Form>(jsonForm);

            return View(form);
        }

        [HttpPost]
        public IActionResult Submit(Form form)
        {
            return View("Index", form);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
