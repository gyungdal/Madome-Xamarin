using System;
using System.Linq;
using System.Reflection;
using Android.Content;
using Android.Support.V4.Widget;
using Madome.Custom.Renderer.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.ListView), typeof(ListViewRefreshRenderer))]
namespace Madome.Custom.Renderer.Droid {
	public class ListViewRefreshRenderer : ListViewRenderer {
		private readonly int Red = 0xff0000;
		public ListViewRefreshRenderer(Context context) : base(context) {
		}
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e) {
			base.OnElementChanged(e);
			if (e.NewElement != null) {
				FieldInfo[] fields = typeof(ListViewRenderer).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
				var refresh = (SwipeRefreshLayout)fields.First(x => x.Name == "_refresh").GetValue(this);
				refresh.SetColorSchemeColors(Red);
			}
		}
	}
}
