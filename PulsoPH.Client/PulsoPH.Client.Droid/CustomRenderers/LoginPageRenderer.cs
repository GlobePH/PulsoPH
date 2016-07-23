using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PulsoPH.Client.Views;
using PulsoPH.Client.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Auth;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace PulsoPH.Client.Droid.CustomRenderers
{
	public class LoginPageRenderer : PageRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);
			var activity = this.Context as Activity;

			var auth = new OAuth2Authenticator(
				clientId: "224616124601353", // your OAuth2 client id
				scope: "public_profile", // the scopes for the particular API you're accessing, delimited by "+" symbols
				authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"), // the auth URL for the service
				redirectUrl: new Uri("http://api-pulsoph.azurewebsites.net")); // the redirect URL for the service

			auth.Completed += (sender, eventArgs) => {
				if (eventArgs.IsAuthenticated)
				{
					App.SuccessfulLoginAction.Invoke();
					// Use eventArgs.Account to do wonderful things
					App.SaveToken(eventArgs.Account.Properties["access_token"]);

					var requestProfile = new OAuth2Request("GET", new Uri("https://graph.facebook.com/v2.7/me?fields=bio,id,first_name,middle_name,last_name,email,birthday"), null, eventArgs.Account);
					requestProfile.GetResponseAsync().ContinueWith(t => {
						if (t.IsFaulted)
							Console.WriteLine("Error: " + t.Exception.InnerException.Message);
						else
						{
							App.GetFacebookUser(t.Result.GetResponseText());

							var requestProfilePicture = new OAuth2Request("GET", new Uri("https://graph.facebook.com/v2.7/me/picture?redirect=false&type=square&height=500"), null, eventArgs.Account);
							requestProfilePicture.GetResponseAsync().ContinueWith(t1 =>
							{
								if (t1.IsFaulted)
									Console.WriteLine("Error: " + t.Exception.InnerException.Message);
								else
								{
									App.GetFacebookUserProfilePicture(t1.Result.GetResponseText());
									App.SuccessfulGetData.Invoke();
								}
							});
						}
					});
				}
				else
				{
					// The user cancelled
				}
			};


			activity.StartActivity(auth.GetUI(activity));
		}
		
	}
}