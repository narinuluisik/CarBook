using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Command.FeatureCommands;
using UdemyCarBook.Application.Features.Mediator.Handlers.FeatureHandlers;
using UdemyCarBook.Application.Features.Mediator.Queries.FeatureQueries;

namespace WebApUdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMediator _meditor;
        public FeaturesController(IMediator meditor)
        {
            _meditor = meditor;
        }
        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _meditor.Send(new GetFeatureQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {
            var value = await _meditor.Send(new GetFeatureByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
        {
            await _meditor.Send(command);
            return Ok("Özellik bilgisi eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveFeature(int id)
        {
            await _meditor.Send(new RemoveFeatureCommand(id));
            return Ok("Özellik bilgisi silindi");
        }
    }

}