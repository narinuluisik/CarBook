using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Command.BlogCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;

namespace WebApUdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _meditor;

        public BlogsController(IMediator meditor)
        {
            _meditor = meditor;
        }
        [HttpGet]
        public async Task<IActionResult> BlogList()
        {
            var values = await _meditor.Send(new GetBlogQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var value = await _meditor.Send(new GetBlogByIdQuery(id));
            if (value == null)
            {
                return NotFound();
            }

            return Ok(value);

        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _meditor.Send(command);
            return Ok("Blog bilgisi eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _meditor.Send(new RemoveBlogCommand(id));
            return Ok("Blog bilgisi silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand    command)
        {
            await _meditor.Send(command);
            return Ok("Yazar bilgisi güncellendi");
        }
        [HttpGet("GetLast3BlogList")]
        public async Task<IActionResult> GetLast3BlogList()
        {
            var values = await _meditor.Send(new GetLast3BlogQuery());
            return Ok(values);
        }
        [HttpGet("GetAllBlogsWithAuthor")]
        public async Task<IActionResult> GetAllBlogsWithAuthor()
        {
            var values = await _meditor.Send(new GetAllBogsWithAuthorQuery());
            return Ok(values);
        }
        [HttpGet("GetBlogByAuthorId")]
        public async Task<IActionResult> GetBlogByAuthorId(int id)
        {
            var values = await _meditor.Send(new GetBlogByAuthorIdQuery(id));
            return Ok(values);
        }

    }
}
