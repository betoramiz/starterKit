using Backend.Application.Feature;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers
{
    [Route("api/feature")]
    [ApiController]
    public class FeatureController : ApiController
    {
        private readonly ISender _mediator;

        public FeatureController(ISender mediator) => _mediator = mediator;

        [HttpPost("create")]
        public async Task<IActionResult> Create(Create.Command command)
        {
            var result = await _mediator.Send(command);
            return result.Match<IActionResult>(
                Ok, error => Problem());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAll.Query());
            return result.Match<IActionResult>(Ok, error => Problem());
        }
    }
}
