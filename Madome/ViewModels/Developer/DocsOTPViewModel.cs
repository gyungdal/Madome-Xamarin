using System;
using System.Diagnostics;
using System.Windows.Input;
using Madome.Helpers;
using Madome.Struct;
using Xamarin.Forms;

namespace Madome.ViewModels.Developer {
	public class DocsOTPViewModel : BaseViewModel {
		public long CountDown { get; set; }
		public string OTP { get; set; }
		public ICommand RefreshCommand { get; private set; }
		private DateTime Expires;
		private bool AlreadyRequest;
		private bool Running;

		public DocsOTPViewModel() {
			AlreadyRequest = false;
			OTP = new string('0', 6);
			Running = true;
			Refresh();
			RefreshCommand = new RelayCommand(Refresh);
			Device.StartTimer(TimeSpan.FromSeconds(1), () => {
				if (!AlreadyRequest) {
					TimeSpan diff = Expires.ToUniversalTime() - DateTime.UtcNow;
					CountDown = Convert.ToInt64(Math.Floor(diff.TotalSeconds));
					OnPropertyChanged("CountDown");
					if (CountDown <= 1) {
						Refresh();
					}
				}
				return Running;
			});
		}

		private void Refresh() {
			AlreadyRequest = true;
			HttpResponse response = APIHelper.Instance.Get(Enum.API.RequestType.OTP_GENERATE);
			OTP = response.Body["otp_code"].ToString();
			long expires = Convert.ToInt64(response.Body["expires"].ToString());
			expires /= 1000;
			Expires = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(expires);
			OnPropertyChanged("OTP");
			AlreadyRequest = false;
		}

		public void Stop() {
			Running = false;
		}
	}
}
