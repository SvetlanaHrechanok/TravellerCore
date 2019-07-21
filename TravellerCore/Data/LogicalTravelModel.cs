using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravellerCore.Data
{
    public class LogicalTravelModel
    {
        public int Id { get; set; }
        [Required]
        public string NameHotel { get; set; }
        [Required]
        public string AboutHotel { get; set; }
        [Range(0, 9999)]
        public int? Price { get; set; }
        [Required]
        public string DateArrival { get; set; }
        [Range(1, 21)]
        public int? AmountDay { get; set; }

        public LogicalTravelModel(int id, string nameHotel, string aboutHotel, int price, string dateArrival, int? amountDay)
        {
            Id = id;
            NameHotel = nameHotel;
            AboutHotel = aboutHotel;
            Price = price;
            DateArrival = dateArrival;
            AmountDay = amountDay;
        }

    }
}
