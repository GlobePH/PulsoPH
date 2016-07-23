using PulsoPH.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PulsoPH.Client.Views
{
	public partial class BaseContentLoginPage : ContentPage
	{
		public BaseContentLoginPage()
		{
			InitializeComponent();
			this.BindingContext = App.LoginViewModel;

			MessagingCenter.Subscribe<LoginViewModel>(this, "NavigateToFacebookLogin", sender => NavigateToFacebookLogin());
			MessagingCenter.Subscribe<LoginViewModel>(this, "NavigateToMainPage", sender => NavigateToMainPage());
			MessagingCenter.Subscribe<LoginViewModel>(this, "NavigateToRegistrationPage", sender => NavigateToRegistrationPage());

		}

		private void NavigateToRegistrationPage()
		{
			Device.BeginInvokeOnMainThread(() =>
			{
				Navigation.InsertPageBefore(App.GetMainPage(), this);
				Navigation.PushAsync(new RegistrationPage());
			});

		}

		private  void NavigateToMainPage()
		{
			Device.BeginInvokeOnMainThread(async () =>
			{
				Navigation.InsertPageBefore(App.GetMainPage(), this);
				await Navigation.PopAsync();
			});
		}

		private void NavigateToFacebookLogin()
		{
			if (!App.IsLoggedIn)
			{
				App.NavPage.Navigation.PushModalAsync(new LoginPage());
			}
		}
	}
}
