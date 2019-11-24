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
		public ObservableCollection<string> Images { get; set; }
		public BookReaderViewModel(int id, string[] book) {
			Images = new ObservableCollection<string>();
			for (int i = 0; i < book.Length; i++) {
				StringBuilder builder = new StringBuilder(APIHelper.Instance.Url);
				builder.Append(String.Format(RequestType.GET_BOOK_IMAGE.GetString(), id, book[i]));
				Images.Add(builder.ToString());
				Debug.WriteLine(Images[i]);
			}
		}
	}
}
