using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Madome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Test : ContentPage
    {
        public ObservableCollection<ImageSource> Items { get; set; }

        public Test()
        {
            InitializeComponent();

            Items = new ObservableCollection<ImageSource>
            {
				ImageSource.FromUri(new Uri("https://static.zerochan.net/Shiratsuyu.%28Kantai.Collection%29.full.2076678.jpg")),
				ImageSource.FromUri(new Uri("https://static.zerochan.net/Shiratsuyu.%28Kantai.Collection%29.full.2676837.jpg")),
				ImageSource.FromUri(new Uri("https://i.imgur.com/zHgsN4s.png")),
				ImageSource.FromUri(new Uri("https://i.imgur.com/YcMW2Qr.png")),
				ImageSource.FromUri(new Uri("https://i.imgur.com/2Gvlihor.png"))
			};

            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", e.Item.ToString(), "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
