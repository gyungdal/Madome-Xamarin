using System;
using System.Collections.Generic;
using Madome.ViewModels.Prepare;
using Xamarin.Forms;

namespace Madome.Views.Prepare {
	public partial class AuthPage : ContentPage {
		private AuthViewModel viewModel;
		public AuthPage(InputEmailViewModel olderViewmodel) {
			viewModel = new AuthViewModel();
			viewModel.Email = olderViewmodel.Email;
			viewModel.Url = olderViewmodel.Url;
			BindingContext = viewModel;
			InitializeComponent();
		}

		private void button_click(object sender, EventArgs args) {
			DisplayAlert(viewModel.Url, "Email : " + viewModel.Email + "\nOTP : " + viewModel.OTP, "Cancel");
		}
	}
}
