using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Command.AppUserCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.AppUserQueries;
using UdemyCarBook.Application.Tools;

namespace WebApUdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegistersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateAppUserCommand command)
        {
              await _mediator.Send(command);
            return Ok("kullancı başarıyla oluşturuldu");
            
        }
    }
}
