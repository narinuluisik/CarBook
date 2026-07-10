using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarPricingInterfaces;
using UdemyCarBook.Application.ViewModels;
using UdemyCarBook.Persistence.Context;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
       private readonly CarBookContext _context;
        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricingViewModel> GetCarPricingWithTimePeriod()
        {
            List<CarPricingViewModel> values = new List<CarPricingViewModel>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"
        SELECT *
        FROM
        (
            SELECT
                Cars.Model,
                Cars.CoverImageUrl,
                Brands.Name AS BrandName,
                CarPricings.PricingID,
                CarPricings.Amount
            FROM CarPricings
            INNER JOIN Cars ON Cars.CarID = CarPricings.CarID
            INNER JOIN Brands ON Brands.BrandID = Cars.BrandID
        ) AS SourceTable
        PIVOT
        (
            SUM(Amount)
            FOR PricingID IN ([2],[3],[4])
        ) AS PivotTable";

                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
                        {
                            Model = reader["Model"].ToString(),
                            CoverImageUrl = reader["CoverImageUrl"].ToString(),
                            BrandName = reader["BrandName"].ToString(),

                            Amounts = new List<decimal>
                    {
                        reader["2"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["2"]),
                        reader["3"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["3"]),
                        reader["4"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["4"])
                    }
                        };

                        values.Add(carPricingViewModel);
                    }
                }

                _context.Database.CloseConnection();
            }

            return values;
        }
        public List<CarPricing> GetCarsPricingWithCars()
        {
           var values= _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z=>z.PricingID==2).ToList();
            return values;

        }

       public List<CarPricing> GetCarsPricingWithTimePeriod()
        {
            throw new NotImplementedException();
        }
    }


    //var values= from x in _context.CarPricings
    //            group x by x.PricingID into g
    //            select new 
    //            {  
    //                CarId=g.Key,
    //                DailyPrice= g.Where(x => x.PricingID == 2).Select(x => x.Amount).FirstOrDefault(),
    //                WeeklyPrice= g.Where(x => x.PricingID == 3).Select(x => x.Amount).FirstOrDefault(),
    //                MonthlyPrice= g.Where(x => x.PricingID == 4).Select(x => x.Amount).FirstOrDefault()


    //            };
}
