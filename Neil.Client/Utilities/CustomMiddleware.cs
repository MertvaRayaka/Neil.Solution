using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Neil.Client.Utilities
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private string _str;
        public CustomMiddleware(RequestDelegate requestDelegate,string str)
        {
            _next = requestDelegate;
            _str = str;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            Console.WriteLine($"{this.GetType().Name}(in){_str}");
            await _next(httpContext);
            Console.WriteLine($"{this.GetType().Name}(out){_str}");
        }
    }
}
