using System;
using Madome.Custom.Auth;
using Madome.Helpers;
using Xamarin.Forms;

namespace Madome.ViewModels {
    public class BaseViewModel : ObservableObject {
        public App AppCurrent {
            get
            {
                return (App)Xamarin.Forms.Application.Current;
            }
        }

        public IAccountManager Account
			=> DependencyService.Get<IAccountManager>();
        

		public string GetUrl
			=> Account.Url;

		

    }
}
