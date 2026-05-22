using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Command.TestimonialCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.TestimoialQueries;

namespace WebApUdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly IMediator _meditor;

        public TestimonialController(IMediator meditor)
        {
            _meditor = meditor;
        }
        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var values = await _meditor.Send(new GetTestimonialQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(int id)
        {
            var value = await _meditor.Send(new GetTestimonialByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand command)
        {
            await _meditor.Send(command);
            return Ok("Referans bilgisi eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            await _meditor.Send(new RemoveTestimonialCommand(id));
            return Ok("Referans bilgisi silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand command)
        {
            await _meditor.Send(command);
            return Ok("Referans bilgisi güncellendi");
        }
    }
}
