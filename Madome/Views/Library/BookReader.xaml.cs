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
	}
}
