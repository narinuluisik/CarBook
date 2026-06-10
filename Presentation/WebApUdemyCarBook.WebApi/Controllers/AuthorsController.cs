using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Command.AuthorCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.AuthorQueries;

namespace WebApUdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _meditor;

        public AuthorsController(IMediator meditor)
        {
            _meditor = meditor;
        }
        [HttpGet]
        public async Task<IActionResult> AuthorList()
        {
            var values = await _meditor.Send(new GetAuthorQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var value = await _meditor.Send(new GetAuthorByIdQuery(id));
            return Ok(value);

        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorCommand command)
        {
            await _meditor.Send(command);
            return Ok("Yazar bilgisi eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            await _meditor.Send(new RemoveAuthorCommand (id));
            return Ok("Yazar bilgisi silindi");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand command)
        {
            await _meditor.Send(command);
            return Ok("Yazar bilgisi güncellendi");
        }
    }
}
