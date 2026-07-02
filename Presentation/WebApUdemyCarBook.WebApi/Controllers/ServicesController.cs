using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Command.ServiceCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.ServiceQueries;

namespace WebApUdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _meditor;

        public ServicesController(IMediator meditor)
        {
            _meditor = meditor;
        }
            [HttpGet]
            public async Task<IActionResult> Get()
            {
                var values = await _meditor.Send(new GetServiceQuery());
                return Ok(values);
        }
            [HttpGet("{id}")]
            public async Task<IActionResult> Get(int id)
            {
                var value = await _meditor.Send(new GetServiceByIdQuery(id));
                return Ok(value);
        }
            [HttpPost]
            public async Task<IActionResult> Post(CreateServiceCommands command)
            {
                await _meditor.Send(command);
                return Ok("Hizmet bilgisi eklendi");
        }
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                await _meditor.Send(new RemoveServiceCommands(id));
                return Ok("Hizmet bilgisi silindi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateServiceCommands command)
        {
            await _meditor.Send(command);
            return Ok("Hizmet bilgisi güncellendi");
        }  }
}
