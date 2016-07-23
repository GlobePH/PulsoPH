using Newtonsoft.Json;
using PulsoPH.Client.Helper;
using PulsoPH.Client.Models;
using PulsoPH.Client.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PulsoPH.Client.Services
{
	public interface IAuthService
	{
		Task<ResultValue> Login(string source, string value);
	}
	public class AuthService : IAuthService
	{
		HttpClient client;

		public AuthService()
		{
			client = new HttpClient(new HttpClientHandler() { UseProxy = false, MaxRequestContentBufferSize = Int32.MaxValue });
			client.BaseAddress = new Uri(Constants.ApiUrl);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			client.Timeout = TimeSpan.FromSeconds(60);
		}

		public async Task<ResultValue> Login(string source,string value)
		{
			ExternalLoginAuth loginAuth = new ExternalLoginAuth()
			{
				Source = source,
				Value = value,
			};

			HttpResponseMessage response = await client.PostAsync("api/User/Login",
				new StringContent(JsonConvert.SerializeObject(loginAuth), Encoding.UTF8, "application/json"));

			if (response.IsSuccessStatusCode)
			{
				string output = await response.Content.ReadAsStringAsync();
				ResultValue result = JsonHelper.ExtractFromJson<ResultValue>(output);

				return result;
			}

			return ResultHelper.ReturnValue(false, "Check your internet connection...");
		}
	}
}
