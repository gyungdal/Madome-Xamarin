using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Madome.Models;
using Madome.ViewModels;
using Madome.Views.Book;
using Madome.Views.Developer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Madome.Views {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMaster : ContentPage {
		public ListView ListView;

		public MainMaster() {
			InitializeComponent();

			BindingContext = new MainMasterViewModel();
			ListView = MenuItemsListView;
		}
	}
}