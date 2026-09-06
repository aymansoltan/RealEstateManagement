using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateManagement.Application.Features.Floors.Command;
using RealEstateManagement.Application.Features.Floors.Query;
using RealEstateManagement.Extensions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RealEstateManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FloorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FloorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("createFloor")]
        public async Task<IActionResult> CreateFloor([FromBody] CreateFloorCommand command)
        {
            var identityUserId = User.GetIdentityUserId();
            if (string.IsNullOrEmpty(identityUserId))
                return Unauthorized();

            command.IdentityUserId = identityUserId;

            var floorId =await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateFloor), new { id = floorId }, new { Id = floorId, Message = "Floor created successfully." });
        }

        [HttpGet("building/{buildingId}/floors")]
        public async Task<IActionResult> GetFloorsByBuilding(Guid buildingId)
        {
            var identityUserId = User.GetIdentityUserId();
            if (string.IsNullOrEmpty(identityUserId))
                return Unauthorized();

            var query = new GetFloorsByBuildingQuery
            {
                BuildingId = buildingId,
                IdentityUserId = identityUserId
            };

            var floors = await _mediator.Send(query);
            return Ok(floors);
        }
    }
}
