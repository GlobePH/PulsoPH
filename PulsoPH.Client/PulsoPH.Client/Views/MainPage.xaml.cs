using PulsoPH.Client.Bootstrap;
using PulsoPH.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PulsoPH.Client.Views
{
	public partial class MainPage : MasterDetailPage
	{
		public MainPage()
		{
			InitializeComponent();

			MessagingCenter.Subscribe<MasterPageViewModel>(this, "DetailNavigation", sender => Navigate(sender));
			MessagingCenter.Subscribe<DetailPageViewModel>(this, "NavigateBack", sender => NavigateBack(sender));
			MessagingCenter.Subscribe<DetailPageViewModel>(this, "Pop", sender => Pop(sender));
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			var masterPageViewModel = (MasterPageViewModel)ViewModelLocator.Resolver.Resolve("MasterPageViewModel");
			Navigate(masterPageViewModel);
		}

		private void Pop(DetailPageViewModel sender)
		{
			IsPresented = !IsPresented;
		}

		private async void NavigateBack(DetailPageViewModel sender)
		{
			await Detail.Navigation.PopAsync();
		}

		private async void Navigate(MasterPageViewModel sender)
		{
			if (sender?.SelectedAppGroupItem != null)
			{
				if (!sender.IsNewLoad)
				{
					//Detail = (Page)Activator.CreateInstance(sender.SelectedAppGroupItem.TargetType);
					await Navigation.PushAsync((Page)Activator.CreateInstance(sender.SelectedAppGroupItem.TargetType));
				}

				sender.IsNewLoad = false;
				sender.SelectedAppGroupItem = null;
				IsPresented = false;
			}
		}
	}
}
