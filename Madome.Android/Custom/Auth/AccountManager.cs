using System;
using Madome.Custom.Auth;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Auth;
using Xamarin.Essentials;
using System.Linq;
using Madome.Helpers;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(Madome.Custom.Auth.Droid.AccountManager))]
namespace Madome.Custom.Auth.Droid {
	public class AccountManager : IAccountManager {
		private readonly SecureAccountStore Store;
		private readonly string AppName;

		AccountManager() {
			Store = SecureAccountStore.Instance;
			AppName = AppInfo.Name;
		}

		public string Email {
			get {
				Account account = Store.FindAccountsForServiceAsync(AppName).Result.First();
				if(account != null) {
					return account.Username;
				}
				return String.Empty;
			}
		}


		public string Token {
			get {
				Account account = Store.FindAccountsForServiceAsync(AppName).Result.First();
				if (account != null) {
					return account.Properties["token"];
				}
				return String.Empty;
			}
		}

		public string Url {
			get {
				Account account = Store.FindAccountsForServiceAsync(AppName).Result.First();
				if (account != null) {
					return account.Properties["url"];
				}
				return String.Empty;
			}
		}

		public void Save(string url, string email, string token) {
			Delete();
			Account account = new Account(email);
			account.Properties["token"] = token;
			account.Properties["url"] = url;
			Store.SaveAsync(account, AppName).Wait();
		}

		public bool HasToken {
			get {
				Account account = Store.FindAccountsForServiceAsync(AppName).Result.First();
				if (account != null) {
					return !String.IsNullOrEmpty(account.Properties["token"]);
				}
				return false;
			}
		}

		public void DeleteToken() {
			Save(Url, String.Empty, String.Empty);
		}

		public void Delete() {
			List<Account> accounts = Store.FindAccountsForServiceAsync(AppName).Result;
			foreach (Account account in accounts) {
				if (account != null) {
					Store.RemoveAsync(account, AppName).Wait();
				}
			}
		}
	}
}
