using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Command.CarFeatureCommands
{
    public class UpdateCarFeatureAvailableToFalseCommand   :IRequest
    {
        public int Id { get; set; }

        public UpdateCarFeatureAvailableToFalseCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
