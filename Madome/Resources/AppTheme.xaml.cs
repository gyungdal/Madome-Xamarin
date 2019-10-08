using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Madome.Resources {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppTheme : ResourceDictionary {
		public AppTheme() {
			InitializeComponent();
		}
		public static Func<Color, bool> ChangeToolbarColor;
		public static Func<Color, bool> ChangeStatusBar;
	}
}
