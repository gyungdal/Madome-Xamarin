using System;
using System.Net.Http;
using Madome.Custom.Auth;
using Madome.Custom.Theme;
using Madome.Helpers;
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
				MainPage = new Madome.Views.Main();
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
