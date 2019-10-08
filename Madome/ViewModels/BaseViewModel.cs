using System;
using Madome.Custom.Auth;
using Madome.Helpers;
using Xamarin.Forms;

namespace Madome.ViewModels {
    public class BaseViewModel : ObservableObject {
		private readonly IAccountManager Account;

		public BaseViewModel() {
			Account = DependencyService.Get<IAccountManager>();
		}

        public App AppCurrent
			=> (App)Xamarin.Forms.Application.Current;
            

		public string GetUrl
			=> Account.Url;

		public string GetEmail
			=> Account.Email;

		public string GetToken
			=> Account.Token;

		public bool HasToken
			=> Account.HasToken;
    }
}
