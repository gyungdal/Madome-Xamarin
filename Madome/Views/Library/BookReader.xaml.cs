using System;
using System.Collections.Generic;
using Madome.Models;
using Madome.ViewModels.Library;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Madome.Views.Library {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookReader : CarouselPage {
		private readonly BookReaderViewModel viewModel;
		public BookReader(int id, string[] images) {
			InitializeComponent();
			viewModel = new BookReaderViewModel(id, images);
			BindingContext = viewModel;
		}
	}
}
