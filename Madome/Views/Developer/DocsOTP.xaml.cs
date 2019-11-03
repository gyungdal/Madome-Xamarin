using System;
using System.Collections.Generic;
using Madome.ViewModels.Developer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Madome.Views.Developer {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DocsOTP : ContentPage {
		private readonly DocsOTPViewModel viewModel;

		public DocsOTP() {
			InitializeComponent();
			viewModel = new DocsOTPViewModel();
			BindingContext = viewModel;
		}

		protected override void OnDisappearing() {
			base.OnDisappearing();
			viewModel.Stop();
		}
	}	
}
