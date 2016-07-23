using PulsoPH.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PulsoPH.Client.Views
{
	public partial class RegistrationPage : ContentPage
	{
		public RegistrationPage()
		{
			InitializeComponent();
			BindingContext = App.UserViewModel;
		}

		private async void BtnRegisterClicked(object sender, EventArgs e)
		{
			App.UserViewModel.IsLoading = true;

			App.UserViewModel.AuthRegIndividualUser = new Models.IndividualUserRegAuth()
			{
				FirstName = App.FacebookUserModel.first_name,
				MiddleName = App.FacebookUserModel.middle_name,
				LastName = App.FacebookUserModel.last_name,
				Address = entryAddress.Text,
				FacebookId = App.FacebookUserModel.id,
				Source = "Facebook",
				BirthDate = DateTime.Now,
				Username = App.FacebookUserModel.id, Nickname = ""
			};

			using(HttpClient client = new HttpClient() { MaxResponseContentBufferSize = 1000000 })
			{
				Task<byte[]> download = ProcessURLAsync(App.FacebookUserModel.picture_url, client);
				Byte[] picture = await download;
				ResultValue result =  await App.UserViewModel.Register(picture);
				if (result.Result)
				{
					Device.BeginInvokeOnMainThread(async () =>
					{
						Navigation.InsertPageBefore(App.GetMainPage(), this);
						await Navigation.PopAsync();
					});
				}
				else
				{
					Device.BeginInvokeOnMainThread(async () =>
					{
						await Navigation.PopAsync();
					});
				}
			}


		}

		async Task<byte[]> ProcessURLAsync(string url, HttpClient client)
		{
			var byteArray = await client.GetByteArrayAsync(url);
			return byteArray;
		}

	}
}
