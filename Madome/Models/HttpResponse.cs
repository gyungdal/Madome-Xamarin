﻿using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Madome.Models {
	public struct HttpResponse {
		public HttpStatusCode Code;
		public JObject Body;
	}
}
