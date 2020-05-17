using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FFImageLoading;
using FFImageLoading.Config;
using Madome.Custom.Auth;
using Madome.Helpers;
using Madome.Models;
using Madome.ViewModels.Library;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Madome.Views.Library {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookList : ContentPage {
		private readonly BookListViewModel viewModel;
		
		public BookList() {
			InitializeComponent();
			viewModel = new BookListViewModel();
			BindingContext = viewModel;
			ImageService.Instance.Initialize(new Configuration {
				HttpClient = new HttpClient(
					new AuthHttpImageClientHandler(
						() => APIHelper.Instance.Token
					)
				)
			});
		}

		public void OnMore(object sender, EventArgs e) {
			var mi = ((MenuItem)sender);
			DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
		}

		public void OnDelete(object sender, EventArgs e) {
			var mi = ((MenuItem)sender);
			DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
		}

		public async void Handle_ItemTapped(object sender, ItemTappedEventArgs e) {
			if (e.Item == null)
				return;
			Book book = (Book)e.Item;
			//Deselect Item
			((ListView)sender).SelectedItem = null;
			if (book.Ready) {
				await Navigation.PushAsync(new BookReader(book.Images));
			} else {
				await DisplayAlert("Now Loading...", "로딩중...", "OK");
			}
		}


		public void OnItemAppearing(object Sender, ItemVisibilityEventArgs e) {
			Book item = (Book)e.Item;
			if (!viewModel.IsRefreshing && item == viewModel.Books.Last()) {
				viewModel.LoadingNextAsync().Start();
			}
		}
	}
}
