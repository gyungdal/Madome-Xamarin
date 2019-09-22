using System;
using Android.Accounts;
using Madome.Custom.Auth;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Auth;
using System.Linq;

//TODO : https://github.com/xamarin/Xamarin.Auth/wiki/Migrating-from-AccountStore-to-Xamarin.Essentials-SecureStorage
[assembly: Xamarin.Forms.Dependency(typeof(Madome.Custom.Auth.Droid.AccountManager))]
namespace Madome.Custom.Auth.Droid
{
	public class AccountManager : IAccountManager
	{
		public string Name
		{
			get
			{
				var accounts = AccountStore.Create(Forms.Context).FindAccountsForService("GOE").ToArray();
				foreach (var account in accounts)
				{
					if (account != null)
						return account.Username;
				}
				return null;
			}
		}
		public string Phone
		{
			get
			{
				var accounts = AccountStore.Create(Forms.Context).FindAccountsForService("GOE").ToArray();
				foreach (var account in accounts)
				{
					if (account != null)
						return account.Properties["Phone"];
				}
				return null;
			}
		}

		public string Affiliation
		{
			get
			{
				var accounts = AccountStore.Create(Forms.Context).FindAccountsForService("GOE").ToArray();
				foreach (var account in accounts)
				{
					if (account != null)
						return account.Properties["Affiliation"];
				}
				return null;
			}
		}

		public bool isEtri
		{
			get
			{
				var accounts = AccountStore.Create(Forms.Context).FindAccountsForService("GOE").ToArray();
				foreach (var account in accounts)
				{
					if (account != null)
						return Convert.ToBoolean(account.Properties["isEtri"]);
				}
				return false;
			}
		}
		public string Position
		{
			get
			{
				var accounts = AccountStore.Create(Forms.Context).FindAccountsForService("GOE").ToArray();
				foreach (var account in accounts)
				{
					if (account != null)
						return account.Properties["Position"];
				}
				return null;
			}
		}

		public bool LoginExists
		{
			get
			{
				var accounts = AccountStore.Create(Forms.Context).FindAccountsForService("GOE");
				var enumerable = accounts as IList<Account> ?? accounts.ToList();
				if (enumerable.Any())
					return false;
				else
					return true;
			}
		}
		public void Delete()
		{
			var accounts = AccountStore.Create(Forms.Context).FindAccountsForService("GOE").ToList();
			foreach (var account in accounts)
			{
				AccountStore.Create(Forms.Context).Delete(account, "GOE");
			}
		}

		public void Save(string id, string phone, string affiliation, string position, bool isEtri)
		{
			string[] temp = { id, phone, affiliation, position };
			foreach (var t in temp)
			{
				if (string.IsNullOrEmpty(t) | string.IsNullOrWhiteSpace(t))
				{
					System.Diagnostics.Debug.WriteLine("Account Save Error : Empty Value!");
					return;
				}
			}
			Xamarin.Auth.Account account = new Xamarin.Auth.Account
			{
				Username = id
			};
			account.Properties.Add("Phone", phone);
			account.Properties.Add("Position", position);
			account.Properties.Add("Affiliation", affiliation);
			account.Properties.Add("isEtri", Convert.ToString(isEtri));
			AccountStore.Create(Forms.Context).SaveAsync(account, "GOE");
		}
	}
}
