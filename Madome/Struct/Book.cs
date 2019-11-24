using System;
using Madome.Helpers;

namespace Madome.Struct {
	public class Book : ObservableObject {
		public int Id { get; set; }
		public string Thumb { get; set; }
		public string Title { get; set; }
		public string[] Group { get; set; }
		public string[] Characters { get; set; }
		public string[] Artists { get; set; }
		public string[] Series { get; set; }
		public string[] Tags { get; set; }
		public string Type { get; set; }
		public string Language { get; set; }
		public int PageCount { get; set; }
		public DateTime CreateAt { get; set; }
	}
}
