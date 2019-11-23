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
				JObject json = new JObject {
					{ "email", Email }
				};
				APIHelper.Instance.UrlRefresh(Url);
				APIHelper.Instance.Post(Enum.API.RequestType.AUTH, json);
				Application.Current.MainPage.Navigation.PushAsync(new AuthPage(this));
			});
		}
	}
}
