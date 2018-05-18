using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NCVODMM.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NCVODMM
{
	public class FormAttributeTypeJsonConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(FormAttribute);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject jsonObject = JObject.Load(reader);

			Type type = Type.GetType("NCVODMM.Models." + jsonObject["Type"]);

			return JsonConvert.DeserializeObject(jsonObject.ToString(), type);

			return null;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}
