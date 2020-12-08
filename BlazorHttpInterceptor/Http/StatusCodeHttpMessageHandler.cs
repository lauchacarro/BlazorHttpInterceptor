using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorHttpInterceptor.Http
{
    public class StatusCodeHttpMessageHandler : DelegatingHandler
    {
        private readonly ILogger<StatusCodeHttpMessageHandler> _logger;
        public StatusCodeHttpMessageHandler(ILogger<StatusCodeHttpMessageHandler> logger)
        {
            _logger = logger;
            InnerHandler = new HttpClientHandler();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            var response = await base.SendAsync(request, cancellationToken);
            _logger.LogInformation($"{(int)response.StatusCode} - {response.StatusCode}");
            return response;

        }
    }
}
