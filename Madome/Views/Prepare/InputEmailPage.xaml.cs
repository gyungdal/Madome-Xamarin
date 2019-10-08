using System;
using System.Collections.Generic;
using Madome.ViewModels.Prepare;
using Xamarin.Forms;

namespace Madome.Views.Prepare {
	public partial class InputEmailPage : ContentPage {
		private InputEmailViewModel viewModel;
		public InputEmailPage(string url) {
			viewModel = new InputEmailViewModel();
			viewModel.Url = url;
			BindingContext = viewModel;
			InitializeComponent();
		}
		private void button_click(object sender, EventArgs args) {
			Navigation.PushAsync(new AuthPage(viewModel));
		}
	}
}
