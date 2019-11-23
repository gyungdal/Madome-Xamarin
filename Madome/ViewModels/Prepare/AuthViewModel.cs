using System;
using System.Net;
using System.Net.Http;
using System.Windows.Input;
using Madome.Custom.Auth;
using Madome.Helpers;
using Madome.Views;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Madome.ViewModels.Prepare {
	public class AuthViewModel : ObservableObject {
		public string Url { get; set; }
		public string Email { get; set; }
		public string OTP { get; set; }
		public ICommand ButtonCommand { get; private set; }

		public AuthViewModel() {
		 	ButtonCommand = new RelayCommand(Auth);
		}

		private void Auth() {
			if (!Url.Contains("https://")) {
				Url = "https://" + Url;
			}
			HttpClient client = new HttpClient();
			Uri uri = new Uri(Url + "/v2/auth/token");
			JObject json = new JObject {
				{ "type", "auth_code" },
				{ "code", OTP }
			};
			StringContent content = new StringContent(content: json.ToString(),
										encoding: System.Text.Encoding.UTF8, mediaType: "application/json");
			HttpResponseMessage response = client.PostAsync(uri, content).Result;
			client.Dispose();
			switch (response.StatusCode) {
				case HttpStatusCode.OK: {
						IAccountManager accountManager = DependencyService.Get<IAccountManager>();
						JObject token = JObject.Parse(response.Content.ReadAsStringAsync().Result);
						accountManager.Save(url: Url, email: Email, token: token.GetValue("token").ToString());
						Application.Current.MainPage = new Main();
						break;
					}
				default: {
						Application.Current.MainPage.DisplayAlert(response.StatusCode.ToString(), "인증 에러 발생", "확인");
						break;
					}
			}

		}
	}
}
