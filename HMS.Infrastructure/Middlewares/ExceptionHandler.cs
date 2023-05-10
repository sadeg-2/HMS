using HMS.Core.Exceptions;
using HMS.Core.ViewModels;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Infrastructure.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;

        public ExceptionHandler(RequestDelegate next,
                                IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }

        public async Task Invoke(HttpContext context)
        {
            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature.Error;
            var response = new JsonResponse();
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            switch (exception)
            {
                case DuplicateEmailOrPhoneException _:
                case EntityNotFoundException _:
                case OperationFailedException _:
                case InvalidDataException _:
                    response.msg = $"e:{exception.Message}";
                    response.close = 0;
                    response.status = 0;
                    break;
                default:
                    response.msg = $"e:حدث خطأ ما";
                    response.close = 0;
                    response.status = 0;
                    var requestBody = string.Empty;
                    var req = context.Request;
                    req.EnableBuffering();
                    if (req.Body.CanSeek)
                    {
                        req.Body.Seek(0, SeekOrigin.Begin);
                        using (var reader = new StreamReader(
                            req.Body,
                            Encoding.UTF8,
                            false,
                            8192,
                            true))
                        {
                            requestBody = await reader.ReadToEndAsync();
                        }
                        req.Body.Seek(0, SeekOrigin.Begin);
                    }
                    break;
            }

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(
                JsonConvert.SerializeObject(response)
            );
        }
    }
}
