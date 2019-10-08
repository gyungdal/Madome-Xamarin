using System;
namespace Madome.Resources {
	public enum ScreenTheme {
		DARK, LIGHT
	}
	public class Screen {
		public static int Width;
		public static int Height;
		public static int DPI;
		public static float Density;
		public static double ConvertDpToPixel(double dp) {
			double px = dp * (DPI / Density);
			return px;
		}
		public static double ConvertPixelsToDp(double px) {
			double dp = px / (DPI / Density);
			return dp;
		}
		public static ScreenTheme Theme;
	}
}
