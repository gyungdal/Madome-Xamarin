using System;
using Android.Content;
using Android.Net;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(Madome.Helpers.Droid.NetworkStatusManager))]
namespace Madome.Helpers.Droid {
	public class NetworkStatusManager : INetworkStatusManager {
		public bool IsOnline() {
			var cm = (ConnectivityManager)Android.App.Application.Context.GetSystemService(Context.ConnectivityService);
			return cm.ActiveNetworkInfo == null ? false : cm.ActiveNetworkInfo.IsConnected;
		}
	}
}
