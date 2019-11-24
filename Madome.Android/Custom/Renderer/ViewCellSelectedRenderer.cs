using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using Madome.Custom.Renderer.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.ViewCell), typeof(ViewCellSelectedRenderer))]
namespace Madome.Custom.Renderer.Droid {
	public class ViewCellSelectedRenderer : ViewCellRenderer {
		private Android.Views.View _cellCore;
		private Drawable _unselectedBackground;
		private bool _selected;

		protected override Android.Views.View GetCellCore(Cell item,
														  Android.Views.View convertView,
														  ViewGroup parent,
														  Context context) {
			if (convertView is null) {
				throw new ArgumentNullException(nameof(convertView));
			}

			_cellCore = base.GetCellCore(item, convertView, parent, context);

			_selected = false;
			_unselectedBackground = _cellCore.Background;

			return _cellCore;
		}

		protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs args) {
			base.OnCellPropertyChanged(sender, args);

			if (args.PropertyName == "IsSelected") {
				_selected = !_selected;

				if (_selected) {
					var extendedViewCell = sender as ViewCell;
					_cellCore.SetBackgroundColor(Color.Transparent.ToAndroid());
				} else {
					_cellCore.SetBackground(_unselectedBackground);
				}
			}
		}
	}
}
