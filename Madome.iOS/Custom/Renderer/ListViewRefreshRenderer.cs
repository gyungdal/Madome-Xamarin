using System;
using System.ComponentModel;
using CoreGraphics;
using Madome.Custom.Renderer.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Xamarin.Forms.ListView), typeof(ListViewRefreshRenderer))]
namespace Madome.Custom.Renderer.iOS {
	public class ListViewRefreshRenderer : ListViewRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
			//When refreshing is done, set offset of list to 0,0
			if (e.PropertyName == ListView.IsRefreshingProperty.PropertyName) {
				if (!Element.IsRefreshing) {
				Control.SetContentOffset(new CGPoint(0, 0), false);
				}
			}

			base.OnElementPropertyChanged(sender, e);
		}
	}
}
