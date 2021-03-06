﻿using System;
using System.Net;
using System.Net.Http;
using System.Windows.Input;
using Madome.Custom.Auth;
using Madome.Helpers;
using Madome.Views;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Madome.Enum.API;
using Madome.Models;

namespace Madome.ViewModels.Prepare {
	public class AuthViewModel : ObservableObject {
		public string Url { get; set; }
		public string Email { get; set; }
		public string OTP { get; set; }
		public ICommand ButtonCommand { get; private set; }

		public AuthViewModel() {
		 	ButtonCommand = new RelayCommand(Auth);
		}

		private void Auth() {
			JObject json = new JObject {
				{ "type", "auth_code" },
				{ "code", OTP }
			};
			HttpResponse result = APIHelper.Instance.Post(RequestType.TOKEN, json);
			switch (result.Code) {
				case HttpStatusCode.OK: {
						IAccountManager accountManager = DependencyService.Get<IAccountManager>();
						string token = result.Body.GetValue("token").ToString();
						accountManager.Save(url: Url, email: Email, token: token);
						APIHelper.Instance.Token = token;
						Application.Current.MainPage = new Main();
						break;
					}
				default: {
						Application.Current.MainPage.DisplayAlert(result.Code.ToString(), result.Body["message"].ToString(), "확인");
						break;
					}
			}

		}
	}
}
