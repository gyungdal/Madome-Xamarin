using System;
using Madome.Custom.Control;
using Madome.Custom.Control.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(HideLineEntry), typeof(HideLineEntryRenderer))]
namespace Madome.Custom.Control.iOS {
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
			}
		}
	}
}

