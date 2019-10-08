using System;
using Madome.Custom.Theme;
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
			MainPage = new NavigationPage(new Views.Prepare.SetHostPage());
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
