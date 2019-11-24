using System;
using Android.Content;
using Android.Graphics;
using Madome.Custom.Control;
using Madome.Custom.Control.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(UnderLineLabel), typeof(UnderLineLabelRenderer))]
namespace Madome.Custom.Control.Droid {
	public class UnderLineLabelRenderer : LabelRenderer {
		public UnderLineLabelRenderer(Context context) : base(context) {
		}
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e) {
			base.OnElementChanged(e);

			if (Control != null && Element != null) {
				if (((UnderLineLabel)Element).IsUnderlined) {
					Control.PaintFlags = PaintFlags.UnderlineText;
				}
			}
		}
	}
}
