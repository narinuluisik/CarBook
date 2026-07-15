using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Command.CarFeatureCommands
{
    public class CreateCarFeatureByCarCommand    :IRequest
    {
        public int CarID { get; set; }
        public int FeatureID { get; set; }

        public bool Available { get; set; }

    }
}
