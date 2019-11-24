using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Madome.Custom.Auth {
	public class AuthHttpImageClientHandler : HttpClientHandler {
		private readonly Func<string> GetToken;

		public AuthHttpImageClientHandler(Func<string> getToken) {
			if (getToken == null) throw new ArgumentNullException("getToken");
			GetToken = getToken;
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
			request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(GetToken());
			return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
		}
	}
}
