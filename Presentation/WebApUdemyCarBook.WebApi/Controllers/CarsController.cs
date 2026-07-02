using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticQueries;

namespace WebApUdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;  
        private readonly GetLast5CarsWithBrandQueryHandler _getLast5CarsWithBrandsQueryHandler;
    

        public CarsController(GetCarQueryHandler getCarQueryHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, CreateCarCommandHandler createCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler = null, GetLast5CarsWithBrandQueryHandler getLast5CarsWithBrandsQueryHandler = null)
        {
            _getCarQueryHandler = getCarQueryHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _createCarCommandHandler = createCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
            _getLast5CarsWithBrandsQueryHandler = getLast5CarsWithBrandsQueryHandler;
        }

        // Adres: api/Cars
        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _getCarQueryHandler.Handle();
            return Ok(values);
        }

        // Adres: api/Cars/GetCarWithBrand
        [HttpGet("GetCarWithBrand")] // Çakışmayı önlemek için route eklendi
        public IActionResult GetCarWithBrand()
        {
            var values = _getCarWithBrandQueryHandler.Handle();
            return Ok(values);
        }

        // Adres: api/Cars/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(value);
        }

        // Adres: api/Cars
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok("Araba bilgisi eklendi");
        }

        // Adres: api/Cars/5
        [HttpDelete("{id}")] // ID'yi urlden almak çakışmayı önler ve standarttır
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Araba bilgisi silindi");
        }

        // Adres: api/Cars/RemoveCarByBrandId/5
        [HttpDelete("RemoveCarByBrandId/{id}")] // Diğer silme metoduyla çakışmasın diye adres özelleştirildi
        public async Task<IActionResult> RemoveCarByBrandId(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Markaya ait araba bilgisi silindi");
        }

        // Adres: api/Cars
        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommad command) // 'Commad' hatası düzeltildi
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok("Araba bilgisi güncellendi");
        }
        [HttpGet("GetLast5CarsWithBrands")]
        public IActionResult GetLast5CarsWithBrands()
        {
            var values = _getLast5CarsWithBrandsQueryHandler.Handle();
            return Ok(values);
        }
      
       
    }
}