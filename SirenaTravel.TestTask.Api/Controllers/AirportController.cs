using MediatR;
using Microsoft.AspNetCore.Mvc;
using SirenaTravel.TestTask.Api.Contracts;
using SirenaTravel.TestTask.Api.Contracts.Responses;
using SirenaTravel.TestTask.Application.Airports.Queries.CalculateDistance;
using System.ComponentModel.DataAnnotations;

namespace SirenaTravel.TestTask.Api.Controllers
{
    [ApiController]
    [Route("api/v1")]
    [Produces("text/json")]
    public class AirportController: ControllerBase
    {
        private IMediator _mediator;

        public AirportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(ApiRoutes.Airport.CalculateDistance)]
        [ProducesResponseType(typeof(DistanceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CalculateDistance(
            [FromRoute, Required]string from, 
            [FromRoute, Required]string to)
        {
            return Ok(new DistanceResponse
            {
                Distance = await _mediator.Send(new CalculateDistanceQuery(from, to))
            });
        }
    }
}
