using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace UdemyTraining_ASP.NET_Core_REST_Web_API.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private readonly ILogger<RequestTimeMiddleware> _logger;
        private readonly Stopwatch _stopWatch;

        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            _logger = logger;
            _stopWatch = new Stopwatch();
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopWatch.Start();
            await next.Invoke(context);
            _stopWatch.Stop();

            var elapsedMillisecounds = _stopWatch.ElapsedMilliseconds;
            if (elapsedMillisecounds / 1000 > 4)
            {
                var message =
                    $"Request [{context.Request.Method}] at {context.Request.Path} took {elapsedMillisecounds} ms";
                _logger.LogInformation(message);
            }
        }
    }
}
