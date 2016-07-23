using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PulsoPH.Client.UserControls
{
	public class CustomLabel : Label
	{
		public static readonly BindableProperty FontFamilyNameProperty = BindableProperty.Create("FontFamilyName", typeof(string), typeof(CustomLabel), "");
		public string FontFamilyName
		{
			get { return GetValue(FontFamilyNameProperty).ToString(); }
			set { SetValue(FontFamilyNameProperty, value); }
		}
	}
}
