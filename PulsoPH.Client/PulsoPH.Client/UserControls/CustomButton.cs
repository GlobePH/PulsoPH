using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PulsoPH.Client.UserControls
{
	public class CustomButton : Button
	{
		public static readonly BindableProperty FontFamilyNameProperty = BindableProperty.Create("FontFamilyName", typeof(string), typeof(CustomButton), "");
		public string FontFamilyName
		{
			get { return GetValue(FontFamilyNameProperty).ToString(); }
			set { SetValue(FontFamilyNameProperty, value); }
		}
	}
}
