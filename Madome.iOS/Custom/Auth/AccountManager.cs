using System;
using System.Collections.Generic;
using System.Linq;
using Accounts;
using Madome.Custom.Auth;
using Xamarin.Essentials;
using Xamarin.Auth;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using Madome.Enum.Auth;

[assembly: Xamarin.Forms.Dependency(typeof(Madome.Custom.Auth.iOS.AccountManager))]
namespace Madome.Custom.Auth.iOS{
	public class AccountManager : IAccountManager {
		private readonly string AppName;

		public AccountManager() {
			AppName = AppInfo.Name;
			Debug.Print(AppName);
		}

		public bool HasToken {
			get => !String.IsNullOrEmpty(Get(AccountTokenType.TOKEN));
		}

		public void Delete() {
			SecureStorage.RemoveAll();
		}

		public string Get(AccountTokenType type) {
			try {
				string value = SecureStorage.GetAsync(AppName).Result;
				JObject account = JObject.Parse(value);
				return account.GetValue(type.ToString()).ToString();
			} catch (Exception) {
				return String.Empty;
			}
		}

		public void Save(string url, string email, string token) {
			JObject account = new JObject();
			account.Add(AccountTokenType.EMAIL.ToString(), email);
			account.Add(AccountTokenType.URL.ToString(), url);
			account.Add(AccountTokenType.TOKEN.ToString(), token);
			SecureStorage.SetAsync(AppName, account.ToString());
		}
	}
}
