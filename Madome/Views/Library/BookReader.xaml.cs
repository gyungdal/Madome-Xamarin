using System;
using System.Collections.Generic;
using Madome.Struct;
using Madome.ViewModels.Library;
using Xamarin.Forms;

namespace Madome.Views.Library {
	public partial class BookReader : ContentPage {
		private readonly BookReaderViewModel viewModel;
		public BookReader(Book book) {
			InitializeComponent();
			viewModel = new BookReaderViewModel(book);
			BindingContext = viewModel;
		}
	}
}
