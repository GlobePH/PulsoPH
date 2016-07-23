using GalaSoft.MvvmLight;
using PulsoPH.Client.Models;
using PulsoPH.Client.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PulsoPH.Client.ViewModels
{
	public class MasterPageViewModel : ViewModelBase
	{
		private List<MasterPageItem> _appGroupItems;
		public List<MasterPageItem> AppGroupItems
		{
			get
			{
				return _appGroupItems;
			}
			set
			{
				if (_appGroupItems == value) return;
				_appGroupItems = value;
				RaisePropertyChanged(() => AppGroupItems);
			}
		}

		private bool _isNewLoad;
		public bool IsNewLoad
		{
			get
			{
				return _isNewLoad;
			}
			set
			{
				if (_isNewLoad != value)
				{
					_isNewLoad = value;
					RaisePropertyChanged(() => IsNewLoad);
				}
			}
		}

		private MasterPageItem _selectedAppGroupItem;
		public MasterPageItem SelectedAppGroupItem
		{
			get
			{
				return _selectedAppGroupItem;
			}
			set
			{
				if (_selectedAppGroupItem != value)
				{
					_selectedAppGroupItem = value;
					RaisePropertyChanged(() => SelectedAppGroupItem);
					MessagingCenter.Send<MasterPageViewModel>(this, "OnGetDetailPage");
					MessagingCenter.Send<MasterPageViewModel>(this, "DetailNavigation");
				}
			}
		}

		public MasterPageViewModel()
		{
			AppGroupItems = new List<MasterPageItem>();

			AppGroupItems.Add(new MasterPageItem
			{
				Title = "Account",
				IconSource = "ic_account_box_white_48dp.png",
				TargetType = typeof(AccountPage)
			});
			AppGroupItems.Add(new MasterPageItem
			{
				Title = "Settings",
				IconSource = "ic_settings_white_48dp.png",
				TargetType = typeof(SettingPage)
			});
			AppGroupItems.Add(new MasterPageItem
			{
				Title = "About",
				IconSource = "ic_settings_white_48dp.png",
				TargetType = typeof(AboutPage)
			});

			SelectedAppGroupItem = AppGroupItems[0];
			MessagingCenter.Subscribe<DetailPageViewModel>(this, "OnGetStartupPage", sender => OnGetStartupPage(sender), null);
			IsNewLoad = true;
		}

		private void OnGetStartupPage(DetailPageViewModel sender)
		{
			string pageTitle = "Account";
			this.SelectedAppGroupItem = AppGroupItems.FirstOrDefault(ag => ag.Title == pageTitle);

			if (sender == null) { return; }

			sender.SelectedAppGroupItem = AppGroupItems.FirstOrDefault(ag => ag.Title == pageTitle);
		}
	}
}
