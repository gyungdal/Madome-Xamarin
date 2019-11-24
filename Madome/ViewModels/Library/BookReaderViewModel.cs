using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Madome.Enum.API;
using Madome.Helpers;
using Madome.Struct;
using Xamarin.Forms;

namespace Madome.ViewModels.Library {
	public class BookReaderViewModel : BaseViewModel {
		public string[] Images { get; set; }
		private readonly Book BookItem;
		public BookReaderViewModel(Book book) {
			BookItem = book;
			string[] temp = book.Images;
			Images = new string[temp.Length];
			int id = book.Id;
			for(int i = 0; i < temp.Length; i++) {
				StringBuilder builder = new StringBuilder(APIHelper.Instance.Url);
				builder.Append(String.Format(RequestType.GET_BOOK_IMAGE.GetString(), id, temp[i]));
				Images[i] = builder.ToString();
			}
		}
	}
}
