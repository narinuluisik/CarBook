using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Command.PricingCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.PricingQueries;

namespace WebApUdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly IMediator _meditor;

        public PricingsController(IMediator meditor)
        {
            _meditor = meditor;
        }
        [HttpGet]
        public async Task<IActionResult> PricingList()
        {
            var values = await _meditor.Send(new GetPricingQuery());
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricing(int id)
        {
            var value = await _meditor.Send(new GetPricingByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingCommand command)
        {
            await _meditor.Send(command);
            return Ok("Fiyat bilgisi eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommand command)
        {
            await _meditor.Send(command);
            return Ok("Fiyat bilgisi güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemovePricing(int id)
        {
            await _meditor.Send(new RemovePricingCommand(id));
            return Ok("Fiyat bilgisi silindi");
        }
    }
      
    }
