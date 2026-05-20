using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBookDomain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Commands.CarCommands
{
    public class UpdateCarCommad
    {
        public int CarID { get; set; }
        public int BrandID { get; set; }
        // Navigation Property Kod yazarken
        // car.Brand.Name diyerek markanın ismine ulaşmanı sağlar.
   
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public string Transmission { get; set; }
        public int Km { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
    }
}
