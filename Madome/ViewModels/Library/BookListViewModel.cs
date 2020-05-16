using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Madome.Enum.API;
using Madome.Helpers;
using Madome.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Madome.ViewModels.Library {
	public class BookListViewModel : BaseViewModel {
		public ObservableCollection<Book> Books { get; private set; }
		public ICommand LoadNextPageCommnad { get; private set; }
		public ICommand RefreshCommand { get; private set; }
		public bool IsRefreshing { get; set; }
		private bool AlreadyLoading { get; set; }
		private int Page;
		public BookListViewModel() {
			Page = 0;
			AlreadyLoading = false;
			Books = new ObservableCollection<Book>();
			LoadNextPageCommnad = new RelayCommand(() => {
				if (!AlreadyLoading) {
					AlreadyLoading = true;
					LoadingNextAsync().Start();
					AlreadyLoading = false;
				}
			});

			RefreshCommand = new RelayCommand(() => {
				Page = 0;
				LoadingNext();
			});

			LoadNextPageCommnad.Execute(null);
		}

		public Task LoadingNextAsync() => new Task(()=>LoadingNext());
		public void LoadingNext() {
			int LastPage = Page;
			Page += 1;
			JObject jObject = new JObject();
			jObject.Add("offset", 25);
			jObject.Add("page", Page);
			HttpResponse response = APIHelper.Instance.Get(Enum.API.RequestType.GET_BOOKS, jObject);
			//DateTime.Parse(NewBook["created_at"].ToString(), null, System.Globalization.DateTimeStyles.RoundtripKind),
			switch (response.Code) {
				case System.Net.HttpStatusCode.OK: {
					JArray NewBooks = response.Body["items"] as JArray;
					foreach (JToken NewBook in NewBooks) {
						Book book = NewBook.ToObject<Book>();
						book.ImageUpdate();
						Books.Add(book);
					}
					break;
				}
				default: {
					Application.Current.MainPage.DisplayAlert("Error", response.Body["message"].ToString(), "OK");
					Page = LastPage;
					break;
				}
			}
		}
	}
}
