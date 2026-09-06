using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RealEstateManagement.Application.Features.Buildings.Command;
using RealEstateManagement.Application.Features.Buildings.Query;
using RealEstateManagement.Extensions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RealEstateManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BuildingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BuildingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("createBuilding")]
        public async Task<IActionResult> CrearteBuilding([FromBody] CreateBuildingCommand command)
        {
            var identityUserId = User.GetIdentityUserId();
            if (string.IsNullOrEmpty(identityUserId))
                return Unauthorized();

            command.IdentityUserId = identityUserId;
            var buildingId =await _mediator.Send(command);
            return CreatedAtAction(nameof(CrearteBuilding), new { id = buildingId }, new { Id = buildingId, Message = "Building created successfully." });
        }
        [HttpGet("getAllBuildings")]
        public async Task<IActionResult> GetAllBuildings()
        {
            var identityUserId = User.GetIdentityUserId();
            if (string.IsNullOrEmpty(identityUserId))
                return Unauthorized();
           
            var query = new GetAllBuildingQuery { IdentityUserId = identityUserId };
            var buildings =await  _mediator.Send(query);
            return Ok(buildings);
        }
    }
}
