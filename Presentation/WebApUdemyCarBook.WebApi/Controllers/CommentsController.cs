using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBookDomain.Entities;

namespace WebApUdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _repository;

        public CommentsController(IGenericRepository<Comment> repository)
        {
            _repository = repository;
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

    }
}