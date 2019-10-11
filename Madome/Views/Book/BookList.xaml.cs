using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Madome.Views.Book {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookList : ContentPage {
		public ObservableCollection<string> Items { get; set; }

		public BookList() {
			InitializeComponent();
			Items = new ObservableCollection<string>{
				"https://media.tenor.com/images/8f711b12e00bc1816694bf51909f8b8f/tenor.gif",
				"https://i.pinimg.com/originals/7a/93/ea/7a93ea41d1a1bfa0fb4a8b1645608451.gif",
				"https://media.giphy.com/media/UYzNgRSTf9X1e/giphy.gif",
				"https://media.giphy.com/media/W2JiHcUyeev5u/giphy.gif",
				"https://media.giphy.com/media/862A6X2sooSsw/giphy.gif",
				"https://media.giphy.com/media/X5F32X6Ykash2/giphy.gif",
				"https://media.giphy.com/media/L0qBXPij9Fj7ciA3yG/giphy.gif",
				"https://media0.giphy.com/media/BejdfvEt6eoV2/giphy.gif",
				"https://media.giphy.com/media/itxe9LDFuCos8/giphy.gif",
				"https://media.giphy.com/media/gitTUlujopMc0/giphy.gif",
				"https://media.tenor.com/images/672f902294e980da4a3d6f311ee799cd/tenor.gif",
				"https://media.tenor.com/images/4fd49de4149a6d348e04f2465a3970af/tenor.gif",
				"https://media.tenor.com/images/e5044e1376c3f40bb6bad826e4563608/tenor.gif",
				"https://i.pinimg.com/originals/78/3f/5b/783f5b1c759893fc0c07ced1ddfb4d21.gif",
				"https://thumbs.gfycat.com/AngryPleasingErmine-max-1mb.gif"
			};

			MyListView.ItemsSource = Items;
		}

		async void Handle_ItemTapped(object sender, ItemTappedEventArgs e) {
			if (e.Item == null)
				return;

			await DisplayAlert("Item Tapped", e.Item.ToString(), "OK");

			//Deselect Item
			((ListView)sender).SelectedItem = null;
		}
	}
}
