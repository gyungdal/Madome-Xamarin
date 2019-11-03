using System;
using Madome.Helpers;
using Xamarin.Forms;

namespace Madome.ViewModels.Developer {
	public class DocsOTPViewModel : BaseViewModel {
		private readonly TimerHelper Timer;
		public int CountDown { get; set; }
		public string OTP { get; set; }

		public DocsOTPViewModel() {
			CountDown = 60;
			Timer = new TimerHelper(TimeSpan.FromSeconds(1), ()=> {
				if(CountDown <= 1) {
					CountDown = 60;
				}
			});
		}

		public void Stop() {
			Timer.Stop();
		}
	}
}
