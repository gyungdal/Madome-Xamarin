using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Madome.ViewModels.Prepare;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Madome.Views.Prepare {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AuthPage : ContentPage {
		private AuthViewModel viewModel;
		public AuthPage(InputEmailViewModel olderViewmodel) {
			viewModel = new AuthViewModel {
				Email = olderViewmodel.Email.Trim(),
				Url = olderViewmodel.Url.Trim()
			};
			BindingContext = viewModel;
			InitializeComponent();
		}

		private void button_click(object sender, EventArgs args) {
			if (!viewModel.Url.Contains("https://")) {
				viewModel.Url = "https://" + viewModel.Url;
			}
			HttpClient client = new HttpClient();
			Uri uri = new Uri(viewModel.Url + "/v2/auth/token");
			JObject json = new JObject();
			json.Add("type", "auth_code");
			json.Add("code", viewModel.OTP);
			StringContent content = new StringContent(content: json.ToString(),
										encoding: System.Text.Encoding.UTF8, mediaType: "application/json");
			HttpResponseMessage response =  client.PostAsync(uri, content).Result;
			switch (response.StatusCode) {
				case HttpStatusCode.OK: {
					Application.Current.MainPage = new Test();
					break;
				}
				default: {
					DisplayAlert(response.StatusCode.ToString(), "인증 에러 발생", "확인");
					break;
				}
			}
		}
	}
}
