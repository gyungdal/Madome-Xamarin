using System;
using System.Collections.Generic;
using Madome.ViewModels.Prepare;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Madome.Views.Prepare {

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InputEmailPage : ContentPage {
		private InputEmailViewModel viewModel;
		public InputEmailPage(string url) {
			viewModel = new InputEmailViewModel {
				Url = url
			};	
			BindingContext = viewModel;
			InitializeComponent();
		}
		private void button_click(object sender, EventArgs args) {
			Navigation.PushAsync(new AuthPage(viewModel));
		}
	}
}
