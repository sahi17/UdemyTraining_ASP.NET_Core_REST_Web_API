﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace UdemyTraining_ASP.NET_Core_REST_Web_API.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Someting went wrong");
            }
        }
    }
}
