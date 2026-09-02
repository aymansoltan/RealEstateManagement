using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateManagement.Application.Features.Owners.Command.RegisterOwner;
using RealEstateManagement.Application.Features.Owners.Query.LoginOwner;
using System.Threading.Tasks;

namespace RealEstateManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OwnersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterOwnerCommand command )
        {
            var ownerId = await _mediator.Send(command);

            return Ok(new { Message = "Owner registered successfully", OwnerId = ownerId });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginOwnerQuery query)
        {
            var token = await _mediator.Send(query);
            return Ok(new { Token = token });
        }

       
    }
}
