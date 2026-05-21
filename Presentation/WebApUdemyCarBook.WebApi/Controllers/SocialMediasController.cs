using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Command.SocialMediaCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.SocialMediaQueries;

namespace WebApUdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly IMediator _meditor;

        public SocialMediasController(IMediator meditor)
        {
            _meditor = meditor;
        }
        [HttpGet]
        public async Task<IActionResult> SocialMediaList()
        {
            var values = await _meditor.Send(new GetSocialMediaQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMedia(int id)
        {
            var value = await _meditor.Send(new GetSocialMediaByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommands command)
        {
            await _meditor.Send(command);
            return Ok("Sosyal medya bilgisi eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            await _meditor.Send(new RemoveSocialMediaCommands(id));
            return Ok("Sosyal medya bilgisi silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommands command)
        {
            await _meditor.Send(command);
            return Ok("Sosyal medya bilgisi güncellendi");
        }
    }
}