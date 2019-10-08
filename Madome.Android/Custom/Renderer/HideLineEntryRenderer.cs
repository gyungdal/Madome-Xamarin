using System;
using Android.Content;
using Android.Graphics.Drawables;
using Madome.Custom.Control;
using Madome.Custom.Control.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HideLineEntry), typeof(HideLineEntryRenderer))]
namespace Madome.Custom.Control.Droid {
	public class HideLineEntryRenderer : EntryRenderer {
		public HideLineEntryRenderer(Context context) : base(context) {
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e) {
			base.OnElementChanged(e);

			if (Control != null) {
				if (e.NewElement != null) {
					var customEntry = (HideLineEntry)e.NewElement;
					if (!customEntry.HasBorder) {
						GradientDrawable gradientDrawable = new GradientDrawable();
						gradientDrawable.SetColor(Android.Graphics.Color.Transparent);
						Control.SetBackground(gradientDrawable);
					}
				}
			}
		}
	}
}
