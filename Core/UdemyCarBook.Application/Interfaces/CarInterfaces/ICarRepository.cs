using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        List<Car>GetCarsListWithBrands();
        List<Car> GetLast5CarsWithBrands();
        

    }
}
