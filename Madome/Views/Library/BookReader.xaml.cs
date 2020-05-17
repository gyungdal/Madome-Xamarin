using System;
using System.Collections.Generic;
using Madome.Models;
using Madome.ViewModels.Library;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Madome.Views.Library {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookReader : ContentPage {
		private readonly BookReaderViewModel viewModel;
		public BookReader(string[] url) {
			InitializeComponent();
			viewModel = new BookReaderViewModel(url);
			BindingContext = viewModel;
		}

		public async void PageMoveClicked(System.Object sender, System.EventArgs e) {
			string result = await DisplayPromptAsync("Move Page", "", placeholder: (viewModel.CurrentIndex + 1).ToString(), keyboard: Keyboard.Numeric);
			Int32 page = -1 ;
			if(Int32.TryParse(result, out page)) {
				if (page < 1 || page > viewModel.Images.Count) {
					await DisplayAlert("Alert", "You have been alerted", "OK");
				} else {
					viewModel.CurrentIndex = (page - 1);
				}
			}
		}
	}
}
