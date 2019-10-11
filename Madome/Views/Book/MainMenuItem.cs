using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madome.Views.Book {
	public class MainMenuItem {
		public MainMenuItem() {
			TargetType = typeof(BookList);
		}
		public int Id { get; set; }
		public string Title { get; set; }

		public Type TargetType { get; set; }
	}
}
