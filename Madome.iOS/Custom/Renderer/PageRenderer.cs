using System;
using Madome.Custom.Renderer.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Madome.Resources.Theme;
using Madome.Resources;

[assembly: ExportRenderer(typeof(ContentPage), typeof(Madome.Custom.Renderer.iOS.PageRenderer))]
namespace Madome.Custom.Renderer.iOS {
	public class PageRenderer : Xamarin.Forms.Platform.iOS.PageRenderer {
		protected override void OnElementChanged(VisualElementChangedEventArgs e) {
			base.OnElementChanged(e);

			if (e.OldElement != null || Element == null) {
				return;
			}

			try {
				SetAppTheme();
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine($"\t\t\tERROR: {ex.Message}");
			}
		}

		public override void TraitCollectionDidChange(UITraitCollection previousTraitCollection) {
			base.TraitCollectionDidChange(previousTraitCollection);
			Console.WriteLine($"TraitCollectionDidChange: {TraitCollection.UserInterfaceStyle} != {previousTraitCollection.UserInterfaceStyle}");

			if (this.TraitCollection.UserInterfaceStyle != previousTraitCollection.UserInterfaceStyle) {
				SetAppTheme();
			}
		}

		void SetAppTheme() {
			if (TraitCollection.UserInterfaceStyle == UIUserInterfaceStyle.Dark) {
				Application.Current.Resources = new DarkTheme();
				Screen.Theme = ScreenTheme.DARK;
			} else {
				Application.Current.Resources = new LightTheme();
				Screen.Theme = ScreenTheme.LIGHT;
			}
		}
	}
}
