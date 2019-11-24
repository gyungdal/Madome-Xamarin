using System;
using System.Collections.Generic;
using Madome.Struct;

namespace Madome.ViewModels.Library {
	public class BookReaderViewModel : BaseViewModel {
		public string[] Items;
		private readonly Book BookItem;
		public BookReaderViewModel(Book book) {
			BookItem = book;
		}
	}
}
