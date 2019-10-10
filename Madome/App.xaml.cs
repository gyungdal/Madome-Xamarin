using System;
using System.Net.Http;
using Madome.Custom.Auth;
using Madome.Custom.Theme;
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
			/*IAccountManager Account = DependencyService.Get<IAccountManager>();
			if (Account.HasToken) {
				MainPage = new Madome.Views.Home.MainPage();
			} else {
			}*/
			using (var client = new HttpClient()) {
				Uri uri = new Uri("https://api.madome.app/v1/auth/send-mail");
				JObject json = new JObject();
				json.Add("email", "gyungdal@meu.works");
				StringContent content = new StringContent(json.ToString(), encoding: System.Text.Encoding.UTF8, "application/json");

				client.PostAsync(uri, content);
			}
			MainPage = new NavigationPage(new Madome.Views.Prepare.SetHostPage());
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
