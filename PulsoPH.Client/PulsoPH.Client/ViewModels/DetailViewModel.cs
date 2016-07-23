using GalaSoft.MvvmLight;
using PulsoPH.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PulsoPH.Client.ViewModels
{
	public class DetailPageViewModel : ViewModelBase
	{
		private readonly ICommand _menuCommand;
		public ICommand MenuCommand
		{
			get
			{
				return _menuCommand;
			}
		}

		private readonly ICommand _searchToolCommand;
		public ICommand SearchToolCommand
		{
			get
			{
				return _searchToolCommand;
			}
		}

		private readonly ICommand _searchCommand;
		public ICommand SearchCommand
		{
			get
			{
				return _searchCommand;
			}
		}
		private readonly ICommand _viewDetailCommand;
		public ICommand ViewDetailCommand
		{
			get
			{
				return _viewDetailCommand;
			}
		}
		private readonly ICommand _backCommand;
		public ICommand BackCommand
		{
			get
			{
				return _backCommand;
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
				}
			}
		}

		private bool _isSearchToolVisible;
		public bool IsSearchToolVisible
		{
			get
			{
				return _isSearchToolVisible;
			}
			set
			{
				if (_isSearchToolVisible != value)
				{
					_isSearchToolVisible = value;
					RaisePropertyChanged(() => IsSearchToolVisible);
				}
			}
		}


		public DetailPageViewModel()
		{
			_menuCommand = new Command(MenuCommandExecute);
			_searchToolCommand = new Command(SearchToolCommandExecute);
			_searchCommand = new Command(SearchCommandExecute);
			_backCommand = new Command(BackCommandExecute);
			_viewDetailCommand = new Command(ViewDetailCommandExecute);
			MessagingCenter.Subscribe<MasterPageViewModel>(this, "OnGetDetailPage", sender => OnGetDetailPage(sender));
			MessagingCenter.Send<DetailPageViewModel>(this, "OnGetStartupPage");
			MessagingCenter.Send<DetailPageViewModel>(this, "NavigateStartup");
			Initialize();
		}

		private void Initialize()
		{
			IsSearchToolVisible = false;
		}
		private void BackCommandExecute(object obj)
		{
			MessagingCenter.Send<DetailPageViewModel>(this, "NavigateBack");
		}

		private void SearchCommandExecute(object obj)
		{
			MessagingCenter.Send<DetailPageViewModel>(this, "NavigateToSearchResult");
		}

		public void ViewDetailCommandExecute(object obj)
		{
			MessagingCenter.Send<DetailPageViewModel>(this, "NavigateToResult");
		}

		private void MenuCommandExecute(object args)
		{
			MessagingCenter.Send<DetailPageViewModel>(this, "Pop");
		}

		private void SearchToolCommandExecute(object obj)
		{
			IsSearchToolVisible = !IsSearchToolVisible;
		}

		private void OnGetDetailPage(MasterPageViewModel masterPageViewModel)
		{
			if (masterPageViewModel.SelectedAppGroupItem != null)
			{
				Initialize();
				SelectedAppGroupItem = masterPageViewModel.SelectedAppGroupItem;
			}
		}

	}
}
