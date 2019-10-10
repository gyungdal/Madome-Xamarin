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
			DisplayAlert(viewModel.Url, "Email : " + viewModel.Email + "\nOTP : " + viewModel.OTP, "Cancel");

			System.Net.ServicePointManager.SecurityProtocol =
				SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

			using (var client = new HttpClient()) {
				Uri uri = new Uri("https://" + viewModel.Url.Trim() + "/v2/auth/token");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				JObject json = new JObject();
				json.Add("type", "auth_code");
				json.Add("code", viewModel.OTP.Trim());
				StringContent content = new StringContent(json.ToString(), encoding: System.Text.Encoding.UTF8, "application/json");

				HttpResponseMessage message = client.PostAsync(uri, content).Result;
				DisplayAlert(message.StatusCode.ToString(), message.Content.ToString(), "취소");
			}
			Application.Current.MainPage = new Test();
		}
	}
}
