using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Madome.Custom.Auth;
using Madome.ViewModels.Prepare;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Madome.Views.Prepare {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AuthPage : ContentPage {
		private AuthViewModel viewModel;
		public AuthPage(InputEmailViewModel olderViewmodel) {
			viewModel = new AuthViewModel {
				Email = olderViewmodel.Email.Trim(),
				Url = olderViewmodel.Url.Trim()
			};
			BindingContext = viewModel;
			InitializeComponent();
		}

		protected override void OnAppearing() {
			base.OnAppearing();
			InputEntry.Focus();
		}
	}
}
