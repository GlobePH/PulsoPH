using GalaSoft.MvvmLight;
using Newtonsoft.Json.Linq;
using PulsoPH.Client.Models;
using PulsoPH.Client.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PulsoPH.Client.ViewModels
{
	public class LoginViewModel : ViewModelBase
	{
		private readonly IAuthService _caseService = new AuthService();

		private Command _loginCommand;
		public Command LoginCommand
		{
			get
			{
				return _loginCommand ?? (_loginCommand = new Command(() => LoginCommand_Execute()));

			}
		}

		private void LoginCommand_Execute()
		{
			IsLoading = true;
			MessagingCenter.Send<LoginViewModel>(this, "NavigateToFacebookLogin");
		}

		public async void Login()
		{
			Debug.WriteLine(App.FacebookUserModel.id);
			ResultValue result = await _caseService.Login("Facebook", App.FacebookUserModel.id);

			App.UserViewModel = new UserViewModel();

			if (!result.Result)
			{
				App.UserViewModel.CurrentFacebookUserModel = App.FacebookUserModel;
				App.UserViewModel.CurrentFacebookUserModel.DisplayName = App.FacebookUserModel.first_name + " " + App.FacebookUserModel.middle_name + " " + App.FacebookUserModel.last_name;
				App.UserViewModel.CurrentFacebookUserModel.Address = "";

				MessagingCenter.Send<LoginViewModel>(this, "NavigateToRegistrationPage");
				IsLoading = false;
			}
			else
			{
				var authUser = result.Message as JObject;
				App.UserViewModel.AuthIndividualUser = authUser.ToObject<IndividualUser>();

				MessagingCenter.Send<LoginViewModel>(this, "NavigateToMainPage");
				IsLoading = false;
			}
		}



		private bool _isLoading;
		public bool IsLoading
		{
			get
			{
				return _isLoading;
			}
			set
			{
				if (_isLoading != value)
				{
					_isLoading = value;
					RaisePropertyChanged(() => IsLoading);
				}
			}
		}

		public LoginViewModel()
		{

		}

	}
}
