using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Persistence.Context;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository: ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }
        public List<Car> GetCarsListWithBrands()
        {
            var value = _context.Cars.Include(x => x.Brand).ToList();
            return value;
        }

  

        List<Car> ICarRepository.GetLast5CarsWithBrands()
        {
            var value = _context.Cars.Include(x => x.Brand).OrderByDescending(x => x.CarID).Take(5).ToList();
            return value;
        }
    }
}
