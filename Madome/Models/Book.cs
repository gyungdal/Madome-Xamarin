using System;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Madome.Custom.Converter;
using Madome.Enum.API;
using Madome.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Madome.Models {
	public class Book : ObservableObject {
		public Book() {
			Ready = false;
		}
		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }

		[JsonProperty(PropertyName = "group")]
		public string[] Group { get; set; }
		public string GroupLine => string.Join(", ", Group);

		[TypeConverter(typeof(ArrayStringConverter))]
		[JsonProperty(PropertyName = "characters")]
		public string[] Characters { get; set; }
		public string CharactersLine => string.Join(", ", Characters);


		[TypeConverter(typeof(ArrayStringConverter))]
		[JsonProperty(PropertyName = "artists")]
		public string[] Artists { get; set; }
		public string ArtistsLine => string.Join(", ", Artists);

		[TypeConverter(typeof(ArrayStringConverter))]
		[JsonProperty(PropertyName = "series")]
		public string[] Series { get; set; }
		public string SeriesLine => string.Join(", ", Series);

		[TypeConverter(typeof(ArrayStringConverter))]
		[JsonProperty(PropertyName = "tags")]
		public string[] Tags { get; set; }
		public string TagsLine => string.Join(", ", Tags);

		[JsonProperty(PropertyName = "type")]
		public string Type { get; set; }

		[JsonProperty(PropertyName = "language")]
		public string Language { get; set; }

		[JsonProperty(PropertyName = "page_count")]
		public int PageCount { get; set; }

		[JsonProperty(PropertyName = "created_at")]
		public string CreateAt { get; set; }

		public string IdWithType {
			get {
				return string.Format("[{0}] {1}", Id, Type);
			}
		}

		public string Thumb
			=> Images[0];
		
		public string[] Images { get; private set; }
		public bool Ready { get; set; }
		public void ImageUpdate() {
			Task.Run(() => {
				HttpResponse imageResponse = APIHelper.Instance.Get(String.Format(RequestType.GET_BOOK_IMAGE_LIST.GetString(), Id));
				JArray images = (Newtonsoft.Json.Linq.JArray)imageResponse.Body["items"];
				int index = 0;
				Images = new string[images.Count];
				string format = RequestType.GET_BOOK_IMAGE.GetString();
				foreach (string image in images) {
					StringBuilder builder = new StringBuilder(APIHelper.Instance.Url);
					builder.AppendFormat(format, Id, image);
					Images[index] = builder.ToString();
					index += 1;
				}
				OnPropertyChanged("Images");
				OnPropertyChanged("Thumb");
				OnPropertyChanged("Artists");
				OnPropertyChanged("ArtistsLine");
				Ready = true;
			});
		}
	}
}
