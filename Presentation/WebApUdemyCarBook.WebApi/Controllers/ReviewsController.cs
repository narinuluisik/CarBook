using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Command.ReviewCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.ReviewQueries;
using UdemyCarBook.Application.Validators.ReviewValidator;

namespace WebApUdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _meditor;

        public ReviewsController(IMediator meditor)
        {
            _meditor = meditor;
        }
        [HttpGet]
        public async Task<IActionResult> ReviewListByCarId(int id)
        {
            var values = await _meditor.Send(new GetReviewByCarIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewCommand command)
        {
            CreateReviewValidator validator=new CreateReviewValidator();
            var validationResult=validator.Validate(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _meditor.Send(command);
            return Ok("Ekleme işlemi gerçekleşti");

        }
        [HttpPut]
        public async Task<IActionResult> UpdateReview(UpdateReviewCommand command)
        {
            await _meditor.Send(command);
            return Ok("Güncelleme işlemi gerçekleşti");
        }
    }
}