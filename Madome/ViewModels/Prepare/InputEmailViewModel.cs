using System;
using Madome.Helpers;

namespace Madome.ViewModels.Prepare {
	public class InputEmailViewModel : ObservableObject {
		public string Url { get; set; }
		public string Email { get; set; }
	}
}
