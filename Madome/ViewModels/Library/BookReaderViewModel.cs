using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Madome.Enum.API;
using Madome.Helpers;
using Madome.Models;
using Xamarin.Forms;

namespace Madome.ViewModels.Library {
	public class BookReaderViewModel : BaseViewModel {
		public ObservableCollection<string> Images { get; private set; }

		private int _currentIndex;
		public int CurrentIndex {
			get => _currentIndex;
			set {
				_currentIndex = value;
				OnPropertyChanged("Title");
			}
		}
		public string Title {
			get => $"{CurrentIndex} / {Images.Count}";
		}
		public BookReaderViewModel(string[] images) {
			Images = new ObservableCollection<string>(images);
			CurrentIndex = 0;
		}
	}
}
