﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Madome.Custom.Auth;
using Madome.Enum.API;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Madome.Helpers {
	public class MadomeAPIHelper {
		private static readonly Lazy<MadomeAPIHelper> _Instance =
				new Lazy<MadomeAPIHelper>(() => new MadomeAPIHelper());
		public static MadomeAPIHelper Instance {
			get => _Instance.Value;
		}

		private string Url;
		private MadomeAPIHelper() {
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

		private JObject Request(Enum.API.HttpMethod method, Uri uri, StringContent content) {
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
			JObject result = new JObject();
			result.Add("code", (int)response.StatusCode);
			result.Add("body", response.Content.ToString());
			client.Dispose();
			return result;
		}

		public JObject Get(RequestType type, JObject body) {
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

		public JObject Post(RequestType type, JObject body) {
			Uri uri = new Uri(Url + type.GetString());
			StringContent content = new StringContent(content: body.ToString(),
										encoding: System.Text.Encoding.UTF8, mediaType: "application/json");
			return Request(Enum.API.HttpMethod.POST, uri, content);
		}

		public JObject Delete(RequestType type, JObject body) {
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

		public JObject Put(RequestType type, JObject body) {
			Uri uri = new Uri(Url + type.GetString());
			StringContent content = new StringContent(content: body.ToString(),
										encoding: System.Text.Encoding.UTF8, mediaType: "application/json");
			return Request(Enum.API.HttpMethod.PUT, uri, content);
		}
	}
}
