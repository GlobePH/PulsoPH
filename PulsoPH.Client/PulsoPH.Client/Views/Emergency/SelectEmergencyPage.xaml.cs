using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PulsoPH.Client.Views.Emergency
{
	public partial class SelectEmergencyPage : ContentPage
	{
		public SelectEmergencyPage()
		{
			InitializeComponent();
		}

		private async void BtnAddRainStormClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AddEmergencyRainPage());
		}
	}
}
