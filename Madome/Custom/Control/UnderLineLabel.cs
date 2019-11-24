using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Madome.Custom.Control {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public class UnderLineLabel : Label {
		public static readonly BindableProperty IsUnderlinedProperty =
			BindableProperty.Create("IsUnderlined", typeof(bool), typeof(UnderLineLabel), false);

		public bool IsUnderlined {
			get { return (bool)GetValue(IsUnderlinedProperty); }
			set { SetValue(IsUnderlinedProperty, value); }
		}
	}
}
