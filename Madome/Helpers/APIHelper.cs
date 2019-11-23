using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using Madome.Custom.Auth;
using Madome.Enum.API;
using Madome.Struct;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Madome.Helpers {
	public class APIHelper {
		private static readonly Lazy<APIHelper> _Instance =
				new Lazy<APIHelper>(() => new APIHelper());
		public static APIHelper Instance {
			get => _Instance.Value;
		}

		private string Url;
		private APIHelper() {
			UrlRefresh();
		}

		/// <summary>
		/// API Helper에서 사용하는 서버 Url을 바꿉니다
		/// </summary>
		/// <param name="url">서버 URL</param>
		public void UrlRefresh(string url) {
			Url = url;
		}

		/// <summary>
		/// API Helper에서 사용하는 서버 Url을 업데이트 합니다.
		/// </summary>
		public void UrlRefresh() {
			Url = DependencyService.Get<IAccountManager>().Get(Enum.Auth.AccountTokenType.URL);
		}

		private HttpResponse Request(Enum.API.HttpMethod method, Uri uri, StringContent content) {
			Debug.WriteLine(uri.ToString());
			HttpClient client = new HttpClient();
			HttpResponseMessage response = new HttpResponseMessage();
			switch (method) {
				case Enum.API.HttpMethod.POST: {
						response = client.PostAsync(uri, content).Result;
						break;
					}
				case Enum.API.HttpMethod.DELETE: {
						response = client.DeleteAsync(uri).Result;
						break;
					}
				case Enum.API.HttpMethod.GET: {
						response = client.GetAsync(uri).Result;
						break;
					}
				case Enum.API.HttpMethod.PUT: {
						response = client.PutAsync(uri, content).Result;
						break;
					}
			}
			string body = response.Content.ReadAsStringAsync().Result;
			HttpResponse result = new HttpResponse {
				Code = response.StatusCode
			};
			if (string.IsNullOrEmpty(body)) {
				result.Body = new JObject();
			} else {
				result.Body = new JObject(body);
			}
			client.Dispose();
			return result;
		}

		public HttpResponse Get(RequestType type, JObject body) {
			StringBuilder builder = new StringBuilder(Url);
			builder.Append(type.GetString());
			builder.Append("?");
			foreach(KeyValuePair<string, JToken> item in body) {
				builder.Append(item.Key);
				builder.Append('=');
				builder.Append(item.Value);
				builder.Append('&');
			}
			Uri uri = new Uri(builder.ToString());
			return Request(Enum.API.HttpMethod.GET, uri, null);
		}

		public HttpResponse Post(RequestType type, JObject body) {
			Uri uri = new Uri(Url + type.GetString());
			StringContent content = new StringContent(content: body.ToString(),
										encoding: System.Text.Encoding.UTF8, mediaType: "application/json");
			return Request(Enum.API.HttpMethod.POST, uri, content);
		}

		public HttpResponse Delete(RequestType type, JObject body) {
			StringBuilder builder = new StringBuilder(Url);
			builder.Append(type.GetString());
			builder.Append("?");
			foreach (KeyValuePair<string, JToken> item in body) {
				builder.Append(item.Key);
				builder.Append('=');
				builder.Append(item.Value);
				builder.Append('&');
			}
			Uri uri = new Uri(builder.ToString());
			return Request(Enum.API.HttpMethod.DELETE, uri, null);
		}

		public HttpResponse Put(RequestType type, JObject body) {
			Uri uri = new Uri(Url + type.GetString());
			StringContent content = new StringContent(content: body.ToString(),
										encoding: System.Text.Encoding.UTF8, mediaType: "application/json");
			return Request(Enum.API.HttpMethod.PUT, uri, content);
		}
	}
}
