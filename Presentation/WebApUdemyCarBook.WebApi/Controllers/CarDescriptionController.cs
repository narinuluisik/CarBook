using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;

namespace WebApUdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDescriptionController : ControllerBase
    {
        private readonly IMediator _meditor;

        public CarDescriptionController(IMediator meditor)
        {
            _meditor = meditor;
        }
        [HttpGet]
        public async Task<IActionResult> GetDescriptionByCarId(int id)
        {
            var values = await _meditor.Send(new GetCarDescriptionByIdQuery(id));
            return Ok(values);
        }
    }
}
