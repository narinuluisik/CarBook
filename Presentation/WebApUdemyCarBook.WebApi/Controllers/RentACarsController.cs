using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Queries.RentACarQueries;

namespace WebApUdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult>GetRentACarListByLocation(int locationID,bool available)


        {
            GetRentACarQuery query = new GetRentACarQuery
                {
                LocationID = locationID,
                Available = available
                };
            var values =await _mediator.Send(query);
            return Ok(values);
         }
    }
}
