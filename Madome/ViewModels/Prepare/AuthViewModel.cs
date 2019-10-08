using System;
using Madome.Helpers;

namespace Madome.ViewModels.Prepare {
	public class AuthViewModel : ObservableObject {
		public string Url { get; set; }
		public string Email { get; set; }
		public string OTP { get; set; }
	}
}
