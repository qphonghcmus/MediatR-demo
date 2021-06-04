using MediatR;
using Microsoft.AspNetCore.Http;
using Services;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Infrastructure
{
    public class UserIdPipe<TIn, TOut> : IPipelineBehavior<TIn, TOut>
    {
        private HttpContext httpContext;
        public UserIdPipe(IHttpContextAccessor accessor)
        {
            httpContext = accessor.HttpContext;
        }
        public async Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
        {
            //var userId = httpContext.User.Claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.NameIdentifier)).Value;
            if(request is BaseRequest br)
            {
                br.UserId = "woof";
            }
            var result = await next();
            if(result is Response<Car> carResponse)
            {
                carResponse.Data.Name += " Checked";
            }
            return result;
        }
    }
}
