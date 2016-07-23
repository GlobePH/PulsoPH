using Newtonsoft.Json;
using PulsoPH.Client.Helper;
using PulsoPH.Client.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PulsoPH.Client.Services
{
	public interface IUserService
	{
		Task<ResultValue> Register(IndividualUserRegAuth IndividualUserRegAuth, byte[] pictureBytes);
	}
	public class UserService : IUserService
	{
		HttpClient client;

		public UserService()
		{
			client = new HttpClient(new HttpClientHandler() { UseProxy = false, MaxRequestContentBufferSize = Int32.MaxValue });
			client.BaseAddress = new Uri(Constants.ApiUrl);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			client.Timeout = TimeSpan.FromSeconds(60);
		}


		public async Task<ResultValue> Register(IndividualUserRegAuth IndividualUserRegAuth, byte[] pictureBytes)
		{
			using (var DataContent = new MultipartFormDataContent())
			{
				if (pictureBytes != null)
				{
					var imageContent = new ByteArrayContent(pictureBytes);
					imageContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
					{
						Name = "ItemImage",
						FileName = "ItemImage.jpg"
					};
					imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
					DataContent.Add(imageContent);
				}

				var informationContent = JsonConvert.SerializeObject(IndividualUserRegAuth, Formatting.None);
				DataContent.Add(new StringContent(informationContent), "UserData");
				string json = JsonConvert.SerializeObject(IndividualUserRegAuth);
				Debug.WriteLine(json);
				HttpResponseMessage response = await client.PostAsync("api/User/Register", DataContent); // Register User

				if (response.IsSuccessStatusCode)
				{
					dynamic output = await response.Content.ReadAsStringAsync();
					ResultValue result = JsonHelper.ExtractFromJson<ResultValue>(output);
					return result;
				}

				return ResultHelper.ReturnValue(false, "Check your internet connection...");

			}
		}
	}
}
