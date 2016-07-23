using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace PulsoPH.Client.Views
{
	public class BaseContentPage : ContentPage
	{
		public BaseContentPage()
		{
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (!App.IsLoggedIn)
			{
				Navigation.PushModalAsync(new LoginPage());
			}
		}
	}
}
