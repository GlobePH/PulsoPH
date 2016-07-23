using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PulsoPH.Client.Helper
{
	public class EmbeddedResourcesHelper
	{
		public static byte[] GetManifestResourceStream(string resourceName)
		{
			//var assembly = DependencyService.Get<IAssemblyService>().GetExecutingAssembly();

			var assembly = typeof(App).GetTypeInfo().Assembly;

			using (Stream stream = assembly.GetManifestResourceStream(resourceName))
			{
				byte[] result = new byte[stream.Length];
				stream.Read(result, 0, (int)stream.Length);
				return result;
			}
		}
	}
}
