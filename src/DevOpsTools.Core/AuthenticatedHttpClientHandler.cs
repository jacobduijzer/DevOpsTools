using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevOpsTools.Core
{
    public class AuthenticatedHttpClientHandler : DelegatingHandler
    {
        private readonly string _token;

        public AuthenticatedHttpClientHandler(string token) =>
            _token = token ?? throw new ArgumentNullException("Please provide a Personal Access Token");

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var byteArray = Encoding.ASCII.GetBytes($"username:{_token}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}