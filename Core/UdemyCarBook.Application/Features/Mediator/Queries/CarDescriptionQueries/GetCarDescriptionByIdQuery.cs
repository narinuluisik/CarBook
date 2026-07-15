using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.CarDescriptionResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionByIdQuery  :IRequest<GetCarDescriptionQueryResult>
    {
        public int Id { get; set; }
        public GetCarDescriptionByIdQuery(int id)
        {
            Id = id;
        }
    }
}
