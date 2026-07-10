using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.ViewModels;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Interfaces.CarPricingInterfaces
{
    public interface ICarPricingRepository
    {
        List<CarPricing> GetCarsPricingWithCars();
        List<CarPricing> GetCarsPricingWithTimePeriod();
        List<CarPricingViewModel> GetCarPricingWithTimePeriod();

    }
}
