using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PulsoPH.Client.Bootstrap
{
	public class ViewModelResolver
	{
		public ViewModelResolver()
		{ }

		public object Resolve(string viewModelName)
		{
			var vmtype = this.GetType()
				.GetTypeInfo()
				.Assembly
				.DefinedTypes
				.FirstOrDefault(t => t.Name.Equals(viewModelName))
				.AsType();

			return ServiceLocator.Current.GetInstance(vmtype);
		}
	}
}
