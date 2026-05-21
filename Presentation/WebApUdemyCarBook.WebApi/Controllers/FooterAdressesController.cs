using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Command.FooterAdressCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.FooterAdressQueries;

namespace WebApUdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAdressesController : ControllerBase
    {
        private readonly IMediator _meditor;

        public FooterAdressesController(IMediator meditor)
        {
            _meditor = meditor;
        }
        [HttpGet]
        public async Task<IActionResult> FooterAdressesList()
        {
            var values = await _meditor.Send(new GetFooterAdressQuery());
            return Ok(values);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAdresses(int id)
        {
            var value = await _meditor.Send(new GetFooterAdressByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooterAdresses(CreateFooterAdressCommand command)
        {
            await _meditor.Send(command);
            return Ok("Footer adres bilgisi eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveFooterAdresses(int id)
        {
            await _meditor.Send(new RemoveFooterAdressCommand(id));
            return Ok("Footer adres bilgisi silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFooterAdresses(UpdateFooterAdressCommand command)
        {
            await _meditor.Send(command);
            return Ok("Footer adres bilgisi güncellendi");
        }
    }
    }
