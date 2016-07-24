using PulsoPH.Client.Views.Emergency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PulsoPH.Client.Views
{
	public partial class MainMapPage : ContentPage
	{
		public MainMapPage()
		{
			InitializeComponent();
		}

		private async void BtnEmergencyClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SelectEmergencyPage());
		}
	}
}
