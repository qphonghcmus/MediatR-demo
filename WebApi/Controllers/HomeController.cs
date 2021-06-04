using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Cars.Commands;
using Services.Cars.Queries;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Cars")]
    public class HomeController : Controller
    {
        private readonly IMediator mediator;
        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public Task<IEnumerable<Car>> Index()
        {
            return mediator.Send(new GetAllCarsQuery());
        }

        [HttpPost]
        public Task<Response<Car>> Index([FromBody] CreateCarCommand command)
        {
            return mediator.Send(command);
        }
    }
}
