using System;
using Madome.Custom.Auth;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Auth;
using Xamarin.Essentials;
using System.Linq;
using Madome.Helpers;
using System.Threading.Tasks;
using Madome.Enum.Auth;

[assembly: Xamarin.Forms.Dependency(typeof(Madome.Custom.Auth.Droid.AccountManager))]
namespace Madome.Custom.Auth.Droid {
	public class AccountManager : IAccountManager {
		private readonly SecureAccountStore AccountStore;
		private readonly string AppName;

		public AccountManager() {
			AccountStore = SecureAccountStore.Instance;
			AppName = AppInfo.Name;
		}

		public string Get(AccountTokenType type) {
			try {
				Account account = AccountStore.FindAccountsForServiceAsync(AppName).Result.First();
				return account.Properties[type.ToString()];
			} catch (Exception) {
				//값이 없으면 빈값 반환
				return String.Empty;
			}
		}

		public bool HasToken {
			get {
				return !String.IsNullOrEmpty(Get(AccountTokenType.TOKEN));
			}
		}

		public string UpdateToken {
			set {
				Account account = AccountStore.FindAccountsForServiceAsync(AppName).Result.First();
				if(account != null) {
					AccountStore.RemoveAsync(account, AppName).Wait();
					account.Properties[AccountTokenType.TOKEN.ToString()] = value;
					AccountStore.SaveAsync(account, AppName).Wait();
				}
			}
		}

		public void Delete() {
			//Account 데이터 삭제
			AccountStore.FindAccountsForServiceAsync(AppName).Result.ForEach(
				(Xamarin.Auth.Account obj) => AccountStore.RemoveAsync(obj, AppName).Wait());
		}


		public void Save(string url, string email, string token) {
			AccountStore.FindAccountsForServiceAsync(AppName).Result.ForEach(
				(Xamarin.Auth.Account obj) => AccountStore.RemoveAsync(obj, AppName).Wait());
			Account account = new Account("WhoAmI");
			account.Properties[AccountTokenType.EMAIL.ToString()] = email;
			account.Properties[AccountTokenType.TOKEN.ToString()] = token;
			account.Properties[AccountTokenType.URL.ToString()] = url;
			AccountStore.SaveAsync(account, AppName).Wait();
		}
	}
}
