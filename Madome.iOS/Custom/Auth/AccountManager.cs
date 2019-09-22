using System;
using System.Linq;
using Accounts;
using Madome.Custom.Auth;
using Xamarin.Auth;

//TODO : https://github.com/xamarin/Xamarin.Auth/wiki/Migrating-from-AccountStore-to-Xamarin.Essentials-SecureStorage
[assembly: Xamarin.Forms.Dependency(typeof(Madome.Custom.Auth.iOS.AccountManager))]
namespace Madome.Custom.Auth.iOS
{
	public class AccountManager : IAccountManager
	{
		public string Id {
			get {
				//TODO : iOS 에서 앱 이름 받아오는 코드 필요, 현재는 디렉토리 구해오는 코드로 대체됨
				var account = AccountStore.Create().FindAccountsForService(AppContext.BaseDirectory).FirstOrDefault();
				return (account != null) ? account.Username : null;
			}
		}

		public string Phone {
			get {
				var account = AccountStore.Create().FindAccountsForService(App.Current.ClassId).FirstOrDefault();
				return (account != null) ? account.Properties["Phone"] : null;
			}
		}

		public string Affiliation {
			get {
				var account = AccountStore.Create().FindAccountsForService(App.Current.ClassId).FirstOrDefault();
				return (account != null) ? account.Properties["Affiliation"] : null;
			}
		}

		public string Position {
			get {
				var account = AccountStore.Create().FindAccountsForService(App.Current.ClassId).FirstOrDefault();
				return (account != null) ? account.Properties["Position"] : null;
			}
		}

		public bool LoginExists {
			get {
				if (AccountStore.Create().FindAccountsForService(App.Current.ClassId).Any())
					return true;
				else
					return false;
			}
		}
		public string Name => throw new NotImplementedException();

		public string Email => throw new NotImplementedException();

		public DateTime CreatedAt => throw new NotImplementedException();

		public void Delete()
		{
			var account = AccountStore.Create().FindAccountsForService(App.Current.ClassId).FirstOrDefault();
			if (account != null) {
				AccountStore.Create().Delete(account, App.Current.ClassId);
			}
		}


		public void Save(string id, string phone, string affiliation, string position)
		{
			if (!string.IsNullOrWhiteSpace(id) && !string.IsNullOrWhiteSpace(phone)
				&& string.IsNullOrWhiteSpace(affiliation) && string.IsNullOrWhiteSpace(position)) {
				Account account = new Account {
					Username = id
				};
				account.Properties.Add("Phone", phone);
				account.Properties.Add("Affiliation", affiliation);
				account.Properties.Add("Position", position);
				AccountStore.Create().SaveAsync(account, App.Current.ClassId);
			}
		}

		public void Save(string name, string id, string email, DateTime createdAt) {
			throw new NotImplementedException();
		}
	}
	
}
