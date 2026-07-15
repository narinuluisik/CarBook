using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Interfaces.CarDescriptionİnterfaces
{
    public interface ICarDescriptionRepository
    {
        CarDescription GetCarDescription(int CarId);
    }
}
