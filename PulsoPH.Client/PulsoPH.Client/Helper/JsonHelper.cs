using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulsoPH.Client.Helper
{
	public static class JsonHelper
	{
		public static T ExtractFromJson<T>(string jsonString)
		{
			return JsonConvert.DeserializeObject<T>(jsonString);
		}
	}
}
