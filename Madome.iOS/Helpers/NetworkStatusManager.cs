using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using GOE.Helpers.iOS;
using SystemConfiguration;

[assembly: Xamarin.Forms.Dependency(typeof(Madome.Helpers.iOS.NetworkStatusManager))]
namespace Madome.Helpers.iOS {
	public class NetworkStatusManager : INetworkStatusManager {
		public bool IsOnline() {
			NetworkStatus internetStatus = Reachability.InternetConnectionStatus();
			switch (internetStatus) {
				case NetworkStatus.ReachableViaCarrierDataNetwork:
				case NetworkStatus.ReachableViaWiFiNetwork:
					return true;
				case NetworkStatus.NotReachable:
					return false;
				default:
					return false;
			}
		}
	}
}
