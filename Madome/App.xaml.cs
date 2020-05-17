using System;
using System.Net;
using System.Net.Http;
using FFImageLoading;
using FFImageLoading.Config;
using Madome.Custom.Auth;
using Madome.Custom.Theme;
using Madome.Enum.API;
using Madome.Helpers;
using Madome.Models;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Madome
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class App : Application
    {
        public App()
        {
			InitializeComponent();
			APIHelper.Instance.UrlRefresh();
			IAccountManager Account = DependencyService.Get<IAccountManager>();
			if (Account.HasToken) {
				APIHelper.Instance.Token = Account.Get(Enum.Auth.AccountTokenType.TOKEN);
				JObject json = new JObject {
					{ "token_type", "auth_code" }
				};
				HttpResponse result = APIHelper.Instance.Get(RequestType.TOKEN, json);
				switch (result.Code) {
					case HttpStatusCode.OK: {
						MainPage = new Madome.Views.Main();
						break;
					}
					default: {
						Application.Current.MainPage.DisplayAlert(result.Code.ToString(), result.Body.ToString(), "확인");
						Account.Delete();
						MainPage = new NavigationPage(new Madome.Views.Prepare.SetHostPage());
						break;
					}
				}
			} else {
				MainPage = new NavigationPage(new Madome.Views.Prepare.SetHostPage());
			}
		}

        protected override void OnStart(){
			
		}

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

		protected override void OnResume() {
			
		}
	}
}
