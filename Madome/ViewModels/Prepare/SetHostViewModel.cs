using System;
using System.Windows.Input;
using Madome.Helpers;
using Madome.Views.Prepare;
using Xamarin.Forms;

namespace Madome.ViewModels.Prepare {
	public class SetHostViewModel : ObservableObject {
		public string Url { get; set; }
		public ICommand ButtonCommand { get; private set; }
		public SetHostViewModel() {
			ButtonCommand = new RelayCommand(() => {
				Application.Current.MainPage.Navigation.PushAsync(new InputEmailPage(Url));
			});
		}
	}
}
