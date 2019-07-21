using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravellerCore.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public Nullable<int> IdCountry { get; set; }
        public Nullable<int> IdPicture { get; set; }
        public string NameHotel { get; set; }
        public string AboutHotel { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}
