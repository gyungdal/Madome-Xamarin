using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madome.Views.Library;

namespace Madome.Models {
	public class MenuModel {
		public MenuModel() {
			//설정이 안돼있는 경우 기본은 책 리스트
			TargetType = typeof(BookList);
		}

		public string Title { get; set; }
		public Type TargetType { get; set; }
	}
}
