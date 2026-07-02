using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using UdemyCarBook.Dto.AuthorDtos;
using UdemyCarBook.Dto.StatisticDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistic")]
    public class AdminStatisticController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            Random Random = new Random();
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7087/api/Statistic/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                int v1=Random.Next(1, 100); // Generate a random number between 1 and 100
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                ViewBag.v = values.CarCount;
                ViewBag.random1 = v1;

            }
            var responseMessage2 = await client.GetAsync("https://localhost:7087/api/Statistic/GetLocationCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                int locationCountRandom = Random.Next(1, 100); // Generate a random number between 1 and 100
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData2);
                ViewBag.locationCount = values2.LocationCount;
                ViewBag.locationCountRandom = locationCountRandom;

            }
            var responseMessage3 = await client.GetAsync("https://localhost:7087/api/Statistic/GetAuthorCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                int authorCountRandom = Random.Next(1, 100); // Generate a random number between 1 and 100
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData3);
                ViewBag.authorCount = values3.AuthorCount;
                ViewBag.authorCountRandom = authorCountRandom;

            }
            var responseMessage4 = await client.GetAsync("https://localhost:7087/api/Statistic/GetBlogCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                int blogCountRandom = Random.Next(1, 100); // Generate a random number between 1 and 100
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData4);
                ViewBag.blogCount = values4.BlogCount;
                ViewBag.blogCountRandom = blogCountRandom;

            }
            var responseMessage5 = await client.GetAsync("https://localhost:7087/api/Statistic/GetBrandCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                int brandCountRandom = Random.Next(1, 100); // Generate a random number between 1 and 100
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData5);
                ViewBag.brandCount = values5.BrandCount;
                ViewBag.brandCountRandom = brandCountRandom;

            }
            var responseMessage6 = await client.GetAsync("https://localhost:7087/api/Statistic/GetAvgPriceForDaily");
            if (responseMessage6.IsSuccessStatusCode)
            {
                int avgPriceRandom = Random.Next(1, 100); // Generate a random number between 1 and 100
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData6);
                ViewBag.avgPrice = values6.AvgPriceForDaily.ToString("0.00");
                ViewBag.avgPriceRandom = avgPriceRandom;
            }
            var responseMessage7 = await client.GetAsync("https://localhost:7087/api/Statistic/GetAvgPriceForMonthly");
            if (responseMessage7.IsSuccessStatusCode)
            {
                int avgPriceMonthlyRandom = Random.Next(1, 100); // Generate a random number between 1 and 100
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var values7 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData7);
                ViewBag.avgPriceMonthly = values7.AvgPriceForMonthly.ToString("0.00"); ;
                ViewBag.avgPriceMonthlyRandom = avgPriceMonthlyRandom;
            }
            var responseMessage8 = await client.GetAsync("https://localhost:7087/api/Statistic/GetAvgPriceForWeekly");
            if (responseMessage8.IsSuccessStatusCode)
            {
                int avgPriceWeeklyRandom = Random.Next(1, 100); // Generate a random number between 1 and 100
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var values8 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData8);
                ViewBag.avgPriceWeekly = values8.AvgPriceForWeekly.ToString("0.00");
                ViewBag.avgPriceWeeklyRandom = avgPriceWeeklyRandom;
            }
            var responseMessage9 = await client.GetAsync("https://localhost:7087/api/Statistic/GetCarCountByTransmissionIsAuto");
            if (responseMessage9.IsSuccessStatusCode)
            {
                int carCountByTransmissionIsAutoRandom = Random.Next(1, 100); // Generate a random number between 1 and 100
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var values9 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData9);
                ViewBag.carCountByTransmissionIsAuto = values9.CarCountByTransmissionIsAuto;
                ViewBag.carCountByTransmissionIsAutoRandom = carCountByTransmissionIsAutoRandom;
            }
            var responseMessage10 = await client.GetAsync("https://localhost:7087/api/Statistic/GetBrandNameWithMaxCar");
            if (responseMessage10.IsSuccessStatusCode)
            {
                int brandNameWithMaxCarRandom = new Random().Next(1, 100);
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();

                // Artık API nesne döndüğü için DeserializeObject %100 çalışacak:
                var values10 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData10);

                // Buraya yeni property ismini yazıyoruz:
                ViewBag.brandNameWithMaxCar = values10.BrandNameByMaxCar;
                ViewBag.brandNameWithMaxCarRandom = brandNameWithMaxCarRandom;
            }
            var responseMessage11 = await client.GetAsync("https://localhost:7087/api/Statistic/GetBlogTitleByMaxBlogComent");
            if (responseMessage11.IsSuccessStatusCode)
            {
                int blogTitleByMaxBlogComentRandom = new Random().Next(1, 100);
                var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();

                // Artık API nesne döndüğü için DeserializeObject %100 çalışacak:
                var values11 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData11);

                // Buraya yeni property ismini yazıyoruz:
                ViewBag.blogTitleByMaxBlogComent = values11.BlogTitleByMaxBlogComent;
                ViewBag.blogTitleByMaxBlogComentRandom = blogTitleByMaxBlogComentRandom;
            }
            var responseMessage12 = await client.GetAsync("https://localhost:7087/api/Statistic/GetCarCountByKmSmallerThen1000");
            if (responseMessage12.IsSuccessStatusCode)
            {
                int carCountByKmSmallerThen1000Random = Random.Next(1, 100); // Generate a random number between 1 and 100
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
                var values12 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData12);
                ViewBag.carCountByKmSmallerThen1000 = values12.CarCountByKmSmallerThen1000;
                ViewBag.carCountByKmSmallerThen1000Random = carCountByKmSmallerThen1000Random;
            }
            var responseMessage13 = await client.GetAsync("https://localhost:7087/api/Statistic/GetCarCountByFuelGasolineOrDiesel");
            if (responseMessage13.IsSuccessStatusCode)
            {
                int carCountByFuelGasolineOrDieselRandom = Random.Next(1, 100); // Generate a random number between 1 and 100
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
                var values13 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData13);
                ViewBag.carCountByFuelGasolineOrDiesel = values13.CarCountByFuelGasolineOrDiesel;
                ViewBag.carCountByFuelGasolineOrDieselRandom = carCountByFuelGasolineOrDieselRandom;
            }
            var responseMessage14 = await client.GetAsync("https://localhost:7087/api/Statistic/GetCarCountByFuelElectric");
            if (responseMessage14.IsSuccessStatusCode)
            {
                int carCountByFuelElectricRandom = Random.Next(1, 100); // Generate a random number between 1 and 100
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
                var values14 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData14);
                ViewBag.carCountByFuelElectric = values14.CarCountByFuelElectric;
                ViewBag.carCountByFuelElectricRandom = carCountByFuelElectricRandom;
            }
            var responseMessage15 = await client.GetAsync("https://localhost:7087/api/Statistic/GetCarBrandAndModelByRentPriceDailyMax");
            if (responseMessage15.IsSuccessStatusCode)
            {
                int CarBrandAndModelByRentPriceDailyMaxRandom = Random.Next(1, 100); // Generate a random number between 1 and 100
                var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
                var values15 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData15);
                ViewBag.CarBrandAndModelByRentPriceDailyMax = values15.CarBrandAndModelByRentPriceDailyMax;
                ViewBag.CarBrandAndModelByRentPriceDailyMaxRandom = CarBrandAndModelByRentPriceDailyMaxRandom;
            }
            var responseMessage16 = await client.GetAsync("https://localhost:7087/api/Statistic/GetCarBrandAndModelByRentPriceDailyMin");
            if (responseMessage16.IsSuccessStatusCode)
            {
                int CarBrandAndModelByRentPriceDailyMinRandom = Random.Next(1, 100); // Generate a random number between 1 and 100
                var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
                var values16 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData16);
                ViewBag.CarBrandAndModelByRentPriceDailyMin = values16.CarBrandAndModelByRentPriceDailyMin;
                ViewBag.CarBrandAndModelByRentPriceDailyMinRandom = CarBrandAndModelByRentPriceDailyMinRandom;
            }

            return View();
        }
    }
}