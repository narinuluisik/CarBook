using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Command.LocationCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.LocationQueries;

namespace WebApUdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _meditor;

        public LocationsController(IMediator meditor)
        {
            _meditor = meditor;
        }
        [HttpGet]
        public async Task<IActionResult> LocationList()
        {
            var values = await _meditor.Send(new GetLocationQuery());
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(int id)
        {
            var value = await _meditor.Send(new GetLocationByIdQuery(id));
            return Ok(value);

        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
        {
            await _meditor.Send(command);
            return Ok("Konum bilgisi eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            await _meditor.Send(new RemoveLocationCommand(id));
            return Ok("Konum bilgisi silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
        {
            await _meditor.Send(command);
            return Ok("Konum bilgisi güncellendi");
        }
    }
    }
