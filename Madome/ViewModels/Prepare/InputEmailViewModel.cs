using System;
using System.Net.Http;
using System.Windows.Input;
using Madome.Helpers;
using Madome.Views.Prepare;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Madome.ViewModels.Prepare {
	public class InputEmailViewModel : ObservableObject {
		public string Url { get; set; }
		public string Email { get; set; }
		public ICommand ButtonCommand { get; private set; }
		public InputEmailViewModel() {
			ButtonCommand = new RelayCommand(() => {
				if (!Url.Contains("https://")) {
					Url = "https://" + Url;
				}
				HttpClient client = new HttpClient();
				Uri uri = new Uri(Url + "/v1/auth/send-mail");
				JObject json = new JObject();
				json.Add("email", Email);
				StringContent content = new StringContent(content: json.ToString(),
											encoding: System.Text.Encoding.UTF8, mediaType: "application/json");
				client.PostAsync(uri, content);
				Application.Current.MainPage.Navigation.PushAsync(new AuthPage(this));
			});
		}
	}
}
