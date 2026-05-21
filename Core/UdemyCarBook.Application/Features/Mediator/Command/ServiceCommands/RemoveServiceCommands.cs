using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Command.ServiceCommands
{
    public class RemoveServiceCommands  : IRequest
    {
        public int ServiceID { get; set; }
        public RemoveServiceCommands(int serviceID)
        {
            ServiceID = serviceID;
        }
    }
}
