using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateManagement.Application.Features.Units.Command;
using RealEstateManagement.Application.Features.Units.Query;
using RealEstateManagement.Extensions;
using System.Security.Claims;

namespace RealEstateManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UnitController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UnitController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateUnit")]
        public async Task<IActionResult> CreateUnit([FromBody] CreateUnitCommand command)
        {
            var identityUserId = User.GetIdentityUserId();
            if (string.IsNullOrEmpty(identityUserId))
                return Unauthorized();

            command.IdentityUserId = identityUserId;

                var unitId = await _mediator.Send(command);
                return Ok(new { UnitId = unitId });
           
        }

        [HttpGet("building/{buildingId}/units")]
        public async Task<IActionResult> GetUnitsByBuilding(Guid buildingId)
        {
            var identityUserId = User.GetIdentityUserId();
            if (string.IsNullOrEmpty(identityUserId))
                return Unauthorized();

            var query = new GetUnitsByBuildingQuery
            {
                BuildingId = buildingId,
                IdentityUserId = identityUserId
            };

            var units = await _mediator.Send(query);
            return Ok(units);
        }
    }
}
