using System;
using Madome.Custom.Renderer.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Xamarin.Forms.ViewCell), typeof(ViewCellSelectedRenderer))]
namespace Madome.Custom.Renderer.iOS {
	public class ViewCellSelectedRenderer : ViewCellRenderer {
		public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv) {
			var cell = base.GetCell(item, reusableCell, tv);
			var view = item as ViewCell;
			cell.SelectedBackgroundView = new UIView {
				BackgroundColor = Color.Transparent.ToUIColor(),
			};
			return cell;
		}
	}
}
