using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {

        public ErrorHandlingMiddleware()
        {

        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(Exception e)
            {
                context.Response.StatusCode = 500;
                context.Response.WriteAsync("Coś poszło nie tak");
            }
        }
    }
}
