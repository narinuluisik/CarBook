using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Interfaces.StatisticRepository
{
    public interface IStatisticRepository
    {
        int GetCarCount();
        int GetLocationCount();
        int GetAuthorCount();
        int GetBrandCount();
        int GetBlogCount();
        decimal GetAvgRentPriceForDaily();
        decimal GetAvgRentPriceForMonthly();
        decimal GetAvgRentPriceForWeekly();
        int GetCarCountByTransmissionIsAuto();
        string GetBrandNameWithMaxCar();
        string GetBlogTitleByMaxBlogComent();
        int GetCarCountByKmSmallerThen1000();
        int GetCarCountByFuelGasolineOrDiesel();
        int GetCarCountByFuelElectric();
        string GetCarBrandAndModelByRentPriceDailyMax();
        string GetCarBrandAndModelByRentPriceDailyMin();
    }
}
