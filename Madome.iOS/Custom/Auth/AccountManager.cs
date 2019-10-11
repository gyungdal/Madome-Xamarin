using System;
using System.Collections.Generic;
using System.Linq;
using Accounts;
using Madome.Custom.Auth;
using Xamarin.Essentials;
using Xamarin.Auth;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

[assembly: Xamarin.Forms.Dependency(typeof(Madome.Custom.Auth.iOS.AccountManager))]
namespace Madome.Custom.Auth.iOS{
	public class AccountManager : IAccountManager {
		private readonly string AppName;

		public AccountManager() {
			AppName = AppInfo.Name;
			Debug.Print(AppName);
		}

		public string Email {
			get {
				string value = SecureStorage.GetAsync(AppName).Result;
				if (!String.IsNullOrEmpty(value)) {
					JObject account = JObject.Parse(value);
					if (!String.IsNullOrEmpty(account.GetValue("email").ToString())) {
						return account.GetValue("email").ToString();
					}
				}
				return String.Empty;
			}
		}

		public string Token {
			get {
				string value = SecureStorage.GetAsync(AppName).Result;
				if (!String.IsNullOrEmpty(value)) {
					JObject account = JObject.Parse(value);
					if (!String.IsNullOrEmpty(account.GetValue("token").ToString())) {
						return account.GetValue("token").ToString();
					}
				}
				return String.Empty;
			}
		}

		public string Url {
			get {
				string value = SecureStorage.GetAsync(AppName).Result;
				if (!String.IsNullOrEmpty(value)) {
					JObject account = JObject.Parse(value);
					if (!String.IsNullOrEmpty(account.GetValue("url").ToString())) {
						return account.GetValue("url").ToString();
					}
				}
				return String.Empty;
			}
		}

		public bool HasToken {
			get => !String.IsNullOrEmpty(Token);
		}


		public void Save(string url, string email, string token) {
			JObject account = new JObject();
			account.Add("email", email);
			account.Add("url", url);
			account.Add("token", token);
			SecureStorage.SetAsync(AppName, account.ToString());
		}

		public void DeleteToken() {
			Save(Url, String.Empty, String.Empty);
		}

		public void Delete() {
			SecureStorage.RemoveAll();
		}
	}
}
