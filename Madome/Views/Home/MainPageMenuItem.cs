using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madome.Views.Home {
	public class MainPageMenuItem {
		public MainPageMenuItem() {
			TargetType = typeof(MainPageDetail);
		}
		public int Id { get; set; }
		public string Title { get; set; }

		public Type TargetType { get; set; }
	}
}
