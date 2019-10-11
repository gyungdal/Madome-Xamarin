using System;
using System.Collections.Generic;
using System.Net.Http;
using Madome.ViewModels.Prepare;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Madome.Views.Prepare {

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SetHostPage : ContentPage {
		private SetHostViewModel viewModel;
		public SetHostPage() {
			InitializeComponent();
			viewModel = new SetHostViewModel();
			BindingContext = viewModel;
		}

		protected override void OnAppearing() {
			base.OnAppearing();
			InputEntry.Focus();
		}

		private void button_click(object sender, EventArgs args) {
			Navigation.PushAsync(new InputEmailPage(viewModel.Url));
		}
	}
}
