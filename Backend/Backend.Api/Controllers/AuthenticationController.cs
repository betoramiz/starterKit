using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController(IMediator mediator) : ApiController
    {
        
    }
}
