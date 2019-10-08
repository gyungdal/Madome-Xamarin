using System;

using Xamarin.Forms;

namespace Madome.Resources {
	public class AppTheme : ContentPage {
		public AppTheme() {
			Content = new StackLayout {
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}

