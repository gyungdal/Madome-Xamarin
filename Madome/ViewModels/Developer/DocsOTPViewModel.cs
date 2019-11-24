using System;
using System.Windows.Input;
using Madome.Helpers;
using Madome.Struct;
using Xamarin.Forms;

namespace Madome.ViewModels.Developer {
	public class DocsOTPViewModel : BaseViewModel {
		private readonly TimerHelper Timer;
		public int CountDown { get; set; }
		public string OTP { get; set; }
		public ICommand RefreshCommand { get; private set; }
		private bool AlreadyRequest;

		public DocsOTPViewModel() {
			AlreadyRequest = false;
			OTP = new string('0', 6);
			CountDown = 60;
			RefreshCommand = new RelayCommand(Refresh);
			Timer = new TimerHelper(TimeSpan.FromSeconds(1), ()=> {
				if (CountDown <= 1) {
					if (!AlreadyRequest) {
						Refresh();
					}
				} else {
					CountDown -= 1;
				}
			});
			Timer.Start();
		}

		private void Refresh() {
			AlreadyRequest = true;
			HttpResponse response = APIHelper.Instance.Get(Enum.API.RequestType.OTP_GENERATE, null);
			OTP = response.Body["otp_code"].ToString();
			CountDown = 60;
			AlreadyRequest = false;
		}

		public void Stop() {
			Timer.Stop();
		}
	}
}
