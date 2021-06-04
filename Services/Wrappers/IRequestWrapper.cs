using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Wrappers
{
    public interface IRequestWrapper<T> : IRequest<Response<T>> { }
    public interface IHandlerWrapper<Tin, TOut> : IRequestHandler<Tin, Response<TOut>> where Tin : IRequestWrapper<TOut> { }
}
