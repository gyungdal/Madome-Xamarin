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
	public partial class InputEmailPage : ContentPage {
		private InputEmailViewModel viewModel;
		public InputEmailPage(string url) {
			viewModel = new InputEmailViewModel {
				Url = url
			};	
			BindingContext = viewModel;
			InitializeComponent();
		}

		protected override void OnAppearing() {
			base.OnAppearing();
			InputEntry.Focus();
		}

		private void button_click(object sender, EventArgs args) {
			if (!viewModel.Url.Contains("https://")) {
				viewModel.Url = "https://" + viewModel.Url;
			}
			HttpClient client = new HttpClient();
			Uri uri = new Uri(viewModel.Url + "/v1/auth/send-mail");
			JObject json = new JObject();
			json.Add("email", viewModel.Email);
			StringContent content = new StringContent(content: json.ToString(),
										encoding: System.Text.Encoding.UTF8, mediaType: "application/json");
			client.PostAsync(uri, content);
			Navigation.PushAsync(new AuthPage(viewModel));
		}
	}
}
