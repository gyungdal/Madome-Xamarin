using System;
using CoreAnimation;
using CoreGraphics;
using Madome.Custom.Control;
using Madome.Custom.Renderer.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(HideLineEntry), typeof(HideLineEntryRenderer))]
namespace Madome.Custom.Renderer.iOS {
	public class HideLineEntryRenderer : EntryRenderer {
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e) {
			base.OnElementChanged(e);

			if (Control != null) {
				if (e.NewElement == null) {
					var customEntry = (HideLineEntry)e.NewElement;
					if (!customEntry.HasBorder) {
						Control.BorderStyle = UITextBorderStyle.None;
					}
				}

				Control.BorderStyle = UITextBorderStyle.None;
				CALayer bottomBorder = new CALayer {
					Frame = new CGRect(0.0f, Element.HeightRequest - 1, this.Frame.Width, 1.0f),
					BorderWidth = 2.0f,
					BorderColor = Color.White.ToCGColor()
				};

				Control.Layer.AddSublayer(bottomBorder);
				Control.Layer.MasksToBounds = true;
			}
		}
	}
}

