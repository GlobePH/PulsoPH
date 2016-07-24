using Newtonsoft.Json;
using PulsoPH.Client.Models;
using PulsoPH.Client.ViewModels;
using PulsoPH.Client.Views;
using PulsoPH.Client.Views.Emergency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PulsoPH.Client
{
	public partial class App : Application
	{
		public static NavigationPage NavPage;
		public static LoginViewModel LoginViewModel = new LoginViewModel();
		public static UserViewModel UserViewModel;

		public App()
		{
			InitializeComponent();
			NavPage = new NavigationPage(new BaseContentLoginPage());
			//NavPage = new NavigationPage(new AddEmergencyRainPage());
			MainPage = NavPage;
		}

		public static bool IsLoggedIn
		{
			get { return !string.IsNullOrWhiteSpace(_Token); }
		}

		static string _Token;
		public static string Token
		{
			get { return _Token; }
		}

		public static void SaveToken(string token)
		{
			_Token = token;
		}

		public static Page GetMainPage()
		{
			return new MainPage();
		}

		
		public static Action SuccessfulLoginAction
		{
			get
			{
				return new Action(() => {
					NavPage.Navigation.PopModalAsync();
				});
			}
		}

		public static Action SuccessfulGetData
		{
			get
			{
				return new Action(() => {
					App.LoginViewModel.Login();
				});
			}
		}


		static FacebookUserModel _FacebookUserModel;
		public static FacebookUserModel FacebookUserModel
		{
			get { return _FacebookUserModel; }
		}


		public static void GetFacebookUser(string json)
		{
			_FacebookUserModel = JsonConvert.DeserializeObject<FacebookUserModel>(json);
		}

		public static void GetFacebookUserProfilePicture(string json)
		{
			FacebookUserProfilePictureModel picture = JsonConvert.DeserializeObject<FacebookUserProfilePictureModel>(json);
			_FacebookUserModel.picture_url = picture.data.url;
		}
	}
}
