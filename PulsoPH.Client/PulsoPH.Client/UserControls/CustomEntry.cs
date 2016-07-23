using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PulsoPH.Client.UserControls
{
	public class CustomEntry : Entry
	{
		public static readonly BindableProperty HintTextColorProperty = BindableProperty.Create("HintTextColor", typeof(Color), typeof(CustomEntry), new Xamarin.Forms.Color());
		public Xamarin.Forms.Color HintTextColor
		{
			get { return (Xamarin.Forms.Color)GetValue(HintTextColorProperty); }
			set { SetValue(HintTextColorProperty, value); }
		}

		public static readonly BindableProperty FontFamilyNameProperty = BindableProperty.Create("FontFamilyName", typeof(string), typeof(CustomEntry), "");
		public string FontFamilyName
		{
			get { return GetValue(FontFamilyNameProperty).ToString(); }
			set { SetValue(FontFamilyNameProperty, value); }
		}
	}
}
