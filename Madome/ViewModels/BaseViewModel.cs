using System;
using System.ComponentModel;
using System.Reflection;
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

		public string Url
			=> Account.Get(Enum.Auth.AccountTokenType.URL);

		public string Email
			=> Account.Get(Enum.Auth.AccountTokenType.EMAIL);

		public string Token
			=> Account.Get(Enum.Auth.AccountTokenType.TOKEN);
    }
}
