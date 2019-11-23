using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Madome.ViewModels.Prepare;
using Newtonsoft.Json.Linq;
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

		protected override void OnAppearing() {
			base.OnAppearing();
			InputEntry.Focus();
		}
	}
}
