using System;
using System.Collections.ObjectModel;
using Madome.Models;
using Madome.Views.Book;
using Madome.Views.Developer;

namespace Madome.ViewModels {
	class MainMasterViewModel : BaseViewModel {
		public ObservableCollection<MenuModel> MenuItems { get; set; }

		public MainMasterViewModel() {
			MenuItems = new ObservableCollection<MenuModel>(new[]
			{
				new MenuModel { Title = "MainView", TargetType = typeof(BookList) },
				new MenuModel { Title = "OTP", TargetType = typeof(DocsOTP)},
				new MenuModel { Title = "Page 3" },
				new MenuModel { Title = "Page 4" },
				new MenuModel { Title = "Page 5" },
			});
		}
	}
}
