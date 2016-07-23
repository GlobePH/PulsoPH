using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PulsoPH.Client.Views
{
	public partial class MasterPage : ContentPage
	{
		public MasterPage()
		{
			InitializeComponent();
			GridUserInfo.BindingContext = App.UserViewModel.AuthIndividualUser;
			StackLayoutInfo.BindingContext = App.UserViewModel.AuthIndividualUser;
		}
	}
}
