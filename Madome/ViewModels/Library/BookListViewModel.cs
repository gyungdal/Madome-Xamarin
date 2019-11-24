using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Madome.Enum.API;
using Madome.Helpers;
using Madome.Struct;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Madome.ViewModels.Library {
	public class BookListViewModel : BaseViewModel {
		public ObservableCollection<Book> Books { get; private set; }
		public ICommand LoadNextPageCommnad { get; private set; }
		public ICommand RefreshCommand { get; private set; }
		public bool IsRefreshing { get; private set; }

		private int Page;
		public BookListViewModel() {
			Page = 0;
			Books = new ObservableCollection<Book>();
			LoadNextPageCommnad = new RelayCommand(async() => {
				IsRefreshing = true;
				await LoadingNext();
				IsRefreshing = false;
			});
			RefreshCommand = new RelayCommand(async () => {
				Page = 0;
				LoadNextPageCommnad.Execute(null);
			});
			RefreshCommand.Execute(null);
		}

		public async Task LoadingNext() {
			Page += 1;
			JObject jObject = new JObject();
			jObject.Add("offset", 25);
			jObject.Add("page", Page);
			HttpResponse response = APIHelper.Instance.Get(Enum.API.RequestType.GET_BOOKS, jObject);
			//DateTime.Parse(NewBook["created_at"].ToString(), null, System.Globalization.DateTimeStyles.RoundtripKind),
			switch (response.Code) {
				case System.Net.HttpStatusCode.OK: {
					JArray NewBooks = (JArray)response.Body["items"];
					foreach (JToken NewBook in NewBooks) {
						Book book = NewBook.ToObject<Book>();
						book.ImageUpdate();
						Books.Add(book);
						Debug.WriteLine(Books.Count.ToString());
					}
					break;
				}
				default: {
					await Application.Current.MainPage.DisplayAlert("Error", response.Body["message"].ToString(), "OK");
					Page -= 1;
					break;
				}
			}
		}
	}
}
