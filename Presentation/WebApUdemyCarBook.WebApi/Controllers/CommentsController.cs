using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Command.CommentCommands;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBookDomain.Entities;

namespace WebApUdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _repository;
        private readonly IMediator _mediator;

        public CommentsController(IGenericRepository<Comment> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }
        [HttpGet]
        public IActionResult CommentList()
        {
            var result = _repository.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var result = _repository.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            _repository.Create(comment);
            return Ok("Yorum bilgisi eklendi");

        }
        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {    var result = _repository.GetById(id);
            _repository.Remove(result);
            return Ok("Yorum bilgisi silindi");

        }
        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _repository.Update(comment);
            return Ok("Yorum bilgisi güncellendi");
        }
        [HttpGet("CommentListByBlog")]
        public IActionResult CommentListByBlog(int id)
        {
            var comment = _repository.GetCommentsByBlogId(id);
            return Ok(comment);
        }
       

        [HttpGet("GetCommentCountByBlog")]
        public IActionResult CommentCountByBlog(int id)
        {
            var commentCount = _repository.GetCommentCountByBlog(id);
            return Ok(commentCount);
        }

        [HttpPost("CreateCommentWithMediator")]
        public async Task<IActionResult> CreateCommentWithMediator(CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yorum bilgisi eklendi");
        }
    }
}