﻿using System;
using System.ComponentModel;
using System.Reflection;

namespace Madome.Enum.API {
	public enum RequestType {
		[Description("/v1/auth/send-mail")]
		AUTH,
		[Description("/v2/auth/token")]
		TOKEN_GENERATOR
	}

	static class RequestTypeExtensions {
		public static string GetString(this RequestType en) {
			Type type = en.GetType();

			MemberInfo[] memInfo = type.GetMember(en.ToString());

			if (memInfo != null && memInfo.Length > 0) {
				//해당 text 값을 배열로 추출해 옵니다.
				object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

				if (attrs != null && attrs.Length > 0) {
					return ((DescriptionAttribute)attrs[0]).Description;
				}
			}

			return en.ToString();
		}
	}
}
