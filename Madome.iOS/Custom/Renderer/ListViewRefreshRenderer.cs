using System;
using Madome.Custom.Renderer.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Xamarin.Forms.ListView), typeof(ListViewRefreshRenderer))]
namespace Madome.Custom.Renderer.iOS {
	public class ListViewRefreshRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e) {
			base.OnElementChanged(e);

			((UITableViewController)ViewController).RefreshControl.TintColor = UIColor.Red;
		}
	}
}
