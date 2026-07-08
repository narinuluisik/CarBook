using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.RentACarDtos
{
    public class FilterRentACarDto
    {
        [JsonProperty("carId")]
        public int carID { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("coverImageUrl")]
        public string CoverImageUrl { get; set; }

    }
}
