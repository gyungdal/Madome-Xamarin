using System;
using Android.Content;
using Madome.Resources;
using Madome.Resources.Theme;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ContentPage), typeof(Madome.Custom.Renderer.Droid.PageRenderer))]
namespace Madome.Custom.Renderer.Droid {
	public class PageRenderer : Xamarin.Forms.Platform.Android.PageRenderer {
		public PageRenderer(Context context) : base(context) {

		}

		protected override void OnElementChanged(ElementChangedEventArgs<Page> e) {
			base.OnElementChanged(e);

			if (e.OldElement != null || Element == null) {
				return;
			}

			try {
				Application.Current.Resources = new LightTheme();
				Screen.Theme = ScreenTheme.LIGHT;
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine($"\t\t\tERROR: {ex.Message}");
			}
		}
	}
}