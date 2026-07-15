using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Command.CarFeatureCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.CarFeatureQueries;

namespace WebApUdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _meditor;

        public CarFeaturesController(IMediator meditor)
        {
            _meditor = meditor;
        }
        [HttpGet]
        public async Task<IActionResult> CarFeatureListByCarId(int id)
        {
            var values = await _meditor.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);
        }
        [HttpGet("CarFeatureChangeAvailableToFalse")]
         public async Task<IActionResult> CarFeatureChangeAvailableToFalse(int id)
        {
            await _meditor.Send(new UpdateCarFeatureAvailableToFalseCommand(id));
            return Ok("güncelleme yapıldı");
        }
    
        [HttpGet("CarFeatureChangeAvailableToTrue")]
        public async Task<IActionResult> CarFeatureChangeAvailableToTrue(int id)
        {
            await _meditor.Send(new UpdateCarFeatureAvailableToTrueCommand(id));
            return Ok("güncelleme yapıldı");
        }
        [HttpPost]
        public async Task<IActionResult> CreateCarFeature(CreateCarFeatureByCarCommand createCarFeatureCommand)
        {
            await _meditor.Send(createCarFeatureCommand);
            return Ok("ekleme yapıldı");
        }
    }
}
