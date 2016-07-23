using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using PulsoPH.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulsoPH.Client.Bootstrap
{
	public class ViewModelLocator : DynamicObject
	{
		static ViewModelResolver _resolver;

		public ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			SimpleIoc.Default.Register<LoginViewModel>();
			SimpleIoc.Default.Register<MasterPageViewModel>();
		}

		public static ViewModelResolver Resolver
		{
			get
			{
				if (_resolver == null)
				{
					_resolver = new ViewModelResolver();
				}
				return _resolver;
			}
		}

		public object this[string viewModelName]
		{
			get
			{
				return Resolver.Resolve(viewModelName);
			}
		}

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			result = this[binder.Name];
			return true;
		}
	}
}
