using System;
using System.Collections.ObjectModel;
using Madome.Models;
using Madome.Views.Developer;
using Madome.Views.Library;

namespace Madome.ViewModels {
	class MainMasterViewModel : BaseViewModel {
		public ObservableCollection<MenuModel> MenuItems { get; set; }

		public MainMasterViewModel() {
			MenuItems = new ObservableCollection<MenuModel>(new[]
			{
				new MenuModel { Title = "MainView", TargetType = typeof(BookList) },
				new MenuModel { Title = "OTP", TargetType = typeof(DocsOTP)}
			});
		}
	}
}
