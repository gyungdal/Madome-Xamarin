using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms;

namespace Madome.Droid {
	[Activity(Label = "Madome", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true,
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
			base.OnCreate(savedInstanceState);
			FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer: true);
			Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
			Madome.Resources.Screen.Width = (int)Resources.DisplayMetrics.WidthPixels;
			Madome.Resources.Screen.Height = (int)Resources.DisplayMetrics.HeightPixels;
			Madome.Resources.Screen.DPI = (int)Resources.DisplayMetrics.DensityDpi;
			Madome.Resources.Screen.Density = Resources.DisplayMetrics.Density;
			Madome.Resources.OS.Version = new Version((int)Android.OS.Build.VERSION.SdkInt, 0);
			LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}