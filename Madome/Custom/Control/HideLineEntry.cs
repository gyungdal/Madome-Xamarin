using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Madome.Custom.Control {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public class HideLineEntry : Entry{
		public static readonly BindableProperty HasBorderProperty =
		BindableProperty.Create(nameof(HasBorder), typeof(bool), typeof(HideLineEntry), true);

		public bool HasBorder {
			get { return (bool)GetValue(HasBorderProperty); }
			set { SetValue(HasBorderProperty, value); }
		}

		public HideLineEntry() {
			Margin = 2;
		}
	}
}
