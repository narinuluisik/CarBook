using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarCommad command)
        {
            var value = await _repository.GetByIdAsync(command.CarID);
            value.BrandID = command.BrandID;
         
            value.Model = command.Model;
            value.CoverImageUrl = command.CoverImageUrl;
            value.Transmission = command.Transmission;
            value.Km = command.Km;
            value.Seat = command.Seat;
            value.Luggage = command.Luggage;
            value.Fuel = command.Fuel;
            value.BigImageUrl = command.BigImageUrl;

            await _repository.UpdateAsync(value);
        }
    }
}
