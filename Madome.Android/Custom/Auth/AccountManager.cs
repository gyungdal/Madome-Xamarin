using System;
using Madome.Custom.Auth;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Auth;
using Xamarin.Essentials;
using System.Linq;
using Madome.Helpers;
using System.Threading.Tasks;

//TODO : https://github.com/xamarin/Xamarin.Auth/wiki/Migrating-from-AccountStore-to-Xamarin.Essentials-SecureStorage
[assembly: Xamarin.Forms.Dependency(typeof(Madome.Custom.Auth.Droid.AccountManager))]
namespace Madome.Custom.Auth.Droid
{
	public class AccountManager : IAccountManager
	{
		
		public string Name => throw new NotImplementedException();

		public string Phone => throw new NotImplementedException();

		public string Affiliation => throw new NotImplementedException();

		public string Position => throw new NotImplementedException();

		public bool LoginExists => throw new NotImplementedException();

		public bool isEtri => throw new NotImplementedException();

		public string Id => throw new NotImplementedException();

		public string Email => throw new NotImplementedException();

		public DateTime CreatedAt => throw new NotImplementedException();

		public void Delete()
		{
			var accounts = AccountStore.Create(Forms.Context).FindAccountsForService(App.Current.ClassId).ToList();
			foreach (var account in accounts)
			{
				AccountStore.Create(Forms.Context).Delete(account, App.Current.ClassId);
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
			AccountStore.Create(Forms.Context).SaveAsync(account, App.Current.ClassId);
		}

		public void Save(string name, string id, string email, DateTime createdAt) {
			throw new NotImplementedException();
		}
	}
}
