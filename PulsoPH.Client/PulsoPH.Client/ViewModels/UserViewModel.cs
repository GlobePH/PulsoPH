using Newtonsoft.Json.Linq;
using PulsoPH.Client.Helper;
using PulsoPH.Client.Models;
using PulsoPH.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PulsoPH.Client.ViewModels
{
	public class UserViewModel : ViewModelBaseMade
	{
		private readonly IUserService _userService = new UserService();


		private bool _isLoading;
		public bool IsLoading
		{
			get { return _isLoading; }
			set { SetProperty(ref _isLoading, value); }
		}

		private IndividualUser _authIndividualUser;
		public IndividualUser AuthIndividualUser
		{
			get { return _authIndividualUser; }
			set { SetProperty(ref _authIndividualUser, value); }
		}

		private FacebookUserModel _currentFacebookUserModel;
		public FacebookUserModel CurrentFacebookUserModel
		{
			get { return _currentFacebookUserModel; }
			set { SetProperty(ref _currentFacebookUserModel, value); }
		}

		private IndividualUserRegAuth _authRegIndividualUser;
		public IndividualUserRegAuth AuthRegIndividualUser
		{
			get { return _authRegIndividualUser; }
			set { SetProperty(ref _authRegIndividualUser, value); }
		}

		public async Task<ResultValue> Register(byte[] pictureBytes)
		{
			try
			{
				ResultValue result = await _userService.Register(AuthRegIndividualUser, pictureBytes);
				if (result.Result)
				{
					var authUser = result.Message as JObject;
					AuthIndividualUser = authUser.ToObject<IndividualUser>();
				}
				return result;
			}
			catch
			{

			}
			return ResultHelper.ReturnValue(false, "Check your internet connection...");

		}
	}
}
