using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Auth;
using Xamarin.Essentials;

namespace Madome.Helpers {
	public class SecureAccountStore {
		private static readonly Lazy<SecureAccountStore> lazy =
			new Lazy<SecureAccountStore>(() => new SecureAccountStore());

		public static SecureAccountStore Instance { get { return lazy.Value; } }

		public async Task SaveAsync(Account account, string serviceId) {
			var accounts = await FindAccountsForServiceAsync(serviceId);
			accounts.RemoveAll(a => a.Username == account.Username);
			accounts.Add(account);
			var json = JsonConvert.SerializeObject(accounts);
			await SecureStorage.SetAsync(serviceId, json);
		}

		public async Task RemoveAsync(Account account, string serviceId) {
			List<Account> accounts = await FindAccountsForServiceAsync(serviceId);
			accounts.RemoveAll(a => a.Username == account.Username);
			accounts.Add(account);
			var json = JsonConvert.SerializeObject(accounts);
			await SecureStorage.SetAsync(serviceId, json);
		}

		public async Task<List<Account>> FindAccountsForServiceAsync(string serviceId) {
			var json = await SecureStorage.GetAsync(serviceId);

			try {
				return JsonConvert.DeserializeObject<List<Account>>(json);
			} catch {
				
			}
			return new List<Account>();
		}

		public async Task MigrateAllAccountsAsync(string serviceId, IEnumerable<Account> accountStoreAccounts) {
			var wasMigrated = await SecureStorage.GetAsync("XamarinAuthAccountStoreMigrated");

			if (wasMigrated == "1")
				return;

			await SecureStorage.SetAsync("XamarinAuthAccountStoreMigrated", "1");
			var accounts = await FindAccountsForServiceAsync(serviceId);
			foreach (var account in accountStoreAccounts) {
				if (accounts.Any(a => a.Username == account.Username))
					continue;

				accounts.Add(account);
			}

			var json = JsonConvert.SerializeObject(accounts);
			await SecureStorage.SetAsync(serviceId, json);
		}
	}
}
