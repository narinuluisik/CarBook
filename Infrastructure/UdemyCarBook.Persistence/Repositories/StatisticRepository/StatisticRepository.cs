using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.StatisticRepository;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.StatisticRepository
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly CarBookContext _context;

        public StatisticRepository(CarBookContext context)
        {
            _context = context;
        }

      
            public string GetBlogTitleByMaxBlogComent()
        {
            // 1. En çok yorum yapılan blogun ID'sini (int) doğrudan çekiyoruz
            int maxBlogId = _context.Comments
                .GroupBy(x => x.BlogID)
                .OrderByDescending(y => y.Count())
                .Select(z => z.Key)
                .FirstOrDefault();

            // Eğer hiç yorum yoksa veya veri sıfır dönerse direkt önlem alalım
            if (maxBlogId == 0)
            {
                return "Yorum Yapılmış Blog Bulunmamaktadır";
            }

            // 2. Bu ID'ye ait blogun başlığını (Title) çekiyoruz
            string blogName = _context.Blogs
                .Where(x => x.BlogId == maxBlogId)
                .Select(y => y.Title)
                .FirstOrDefault();

            // Veritabanında başlık yoksa null dönmesin diye güvenli çıkış yapıyoruz
            return blogName ?? "Başlıksız Blog";
        }
     

        public string GetBrandNameWithMaxCar()
        {
            // 1. En çok arabası olan markanın ID'sini buluyoruz
            var maxBrandGroup = _context.Cars
                .GroupBy(x => x.BrandID)
                .OrderByDescending(y => y.Count())
                .Select(z => z.Key)
                .FirstOrDefault();

            // Eğer Cars tablosu boşsa veya hiçbir gruba ulaşılamadıysa direkt bilgi dönelim
            if (maxBrandGroup == 0)
            {
                return "Veri Bulunamadı";
            }

            // 2. Bu ID'ye ait markanın adını çekiyoruz
            string brandName = _context.Brands
                .Where(x => x.BrandID == maxBrandGroup)
                .Select(y => y.Name)
                .FirstOrDefault();

            // Eğer marka adı yine de bulunamadıysa (ID var ama Brands tablosunda karşılığı yoksa)
            return brandName ?? "Bilinmeyen Marka";
        }

        public int GetAuthorCount()
        {
           var value = _context.Authors.Count();
            return value;
        }

        public decimal GetAvgRentPriceForDaily()
        {
           int id =_context.Pricings.Where(y=>y.Name=="Günlük").Select(x=>x.PricingID).FirstOrDefault();
           var value = _context.CarPricings.Where(x => x.PricingID == id).Average(x => x.Amount);
            return value;

        }

        public decimal GetAvgRentPriceForMonthly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Aylık").Select(x => x.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(x => x.PricingID == id).Average(x => x.Amount);
            return value;

        }

        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Haftalık").Select(x => x.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(x => x.PricingID == id).Average(x => x.Amount);
            return value;

        }

        public int GetBlogCount()
        {
           var value = _context.Blogs.Count();
            return value;
        }

        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
             int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(x => x.PricingID).FirstOrDefault();
            decimal amaount = _context.CarPricings.Where(y => y.PricingID == pricingId).Max(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amaount).Select(x => x.CarID).FirstOrDefault();
            string brandmodel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandmodel;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(x => x.PricingID).FirstOrDefault();
            decimal amaount = _context.CarPricings.Where(y => y.PricingID == pricingId).Min(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amaount).Select(x => x.CarID).FirstOrDefault();
            string brandmodel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandmodel;
        }

        public int GetCarCountByFuelElectric()
        {
           var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return value;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value;
        }

        public int GetCarCountByKmSmallerThen1000()
        {
           var value = _context.Cars.Where(x => x.Km < 1000).Count();
            return value;
        }

        public int GetCarCountByTransmissionIsAuto()
        {
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return value;
        }

        public int GetLocationCount()
        {  var value = _context.Locations.Count();
            return value;
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }
    }
}
