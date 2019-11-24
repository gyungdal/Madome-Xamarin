using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Madome.Enum.API;
using Madome.Helpers;
using Madome.Struct;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Madome.ViewModels.Library {
	public class BookListViewModel : BaseViewModel {
		public List<Book> Books { get; private set; }
		public ICommand LoadNextPageCommnad { get; private set; }
		public ICommand RefreshCommand { get; private set; }
		public bool IsRefreshing { get; private set; }

		private int Page;
		public BookListViewModel() {
			Page = 0;
			Books = new List<Book>();
			LoadNextPageCommnad = new RelayCommand(LoadingNext);
			RefreshCommand = new RelayCommand(() => {
				IsRefreshing = true;
				Page = 0;
				LoadingNext();
				IsRefreshing = false;
			});
			IsRefreshing = true;
			LoadingNext();
			IsRefreshing = false;
		}

		private void LoadingNext() {
			Page += 1;
			JObject jObject = new JObject();
			jObject.Add("offset", 25);
			jObject.Add("page", Page);
			HttpResponse response = APIHelper.Instance.Get(Enum.API.RequestType.GET_BOOKS, jObject);
			switch (response.Code) {
				case System.Net.HttpStatusCode.OK: {
						JArray NewBooks = (JArray)response.Body["items"];
						foreach (JObject NewBook in NewBooks) {
							Book book = new Book {
								Id = Convert.ToInt32(NewBook["id"]),
								Title = NewBook["title"].ToString(),
								Type = NewBook["type"].ToString(),
								Language = NewBook["language"].ToString(),
								PageCount = Convert.ToInt32(NewBook["page_count"]),
								CreateAt = DateTime.Parse(NewBook["created_at"].ToString(), null, System.Globalization.DateTimeStyles.RoundtripKind),
							};
							HttpResponse imageResponse= APIHelper.Instance.Get(String.Format(RequestType.GET_BOOK_IMAGE_LIST.GetString(), book.Id));
							JArray images = (Newtonsoft.Json.Linq.JArray)imageResponse.Body["items"];
							int index = 0;
							book.Images = new string[images.Count];
							foreach (string image in images) {
								book.Images[index] = image;
								index += 1;
							}
							index = 0;
							JArray groups = (JArray)NewBook["group"];
							book.Group = new string[groups.Count];
							foreach(string group in groups) {
								book.Group[index] = group;
								index += 1;
							}
							index = 0;
							JArray characters = (JArray)NewBook["characters"];
							book.Characters = new string[characters.Count];
							foreach (string character in characters) {
								book.Characters[index] = character;
								index += 1;
							}
							index = 0;
							JArray artists = (JArray)NewBook["artists"];
							book.Artists = new string[artists.Count];
							foreach (string artist in artists) {
								book.Artists[index] = artist;
								index += 1;
							}
							index = 0;
							JArray series = (JArray)NewBook["series"];
							book.Series = new string[series.Count];
							foreach (string serie in series) {
								book.Series[index] = serie;
								index += 1;
							}
							index = 0;
							JArray tags = (JArray)NewBook["tags"];
							book.Tags = new string[tags.Count];
							foreach (string tag in tags) {
								book.Tags[index] = tag;
								index += 1;
							}
							Books.Add(book);
						}
						break;
					}
				default: {
					Application.Current.MainPage.DisplayAlert("Error", response.Body["message"].ToString(), "OK");
					Page -= 1;
					break;
				}
			}
		}
	}
}
