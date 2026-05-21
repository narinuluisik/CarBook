using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Command.SocialMediaCommands
{
    public class RemoveSocialMediaCommands  :IRequest
    {
        public int SocialMediaID { get; set; }
        public RemoveSocialMediaCommands(int socialMediaID)
        {
            SocialMediaID = socialMediaID;
        }
    }
}
