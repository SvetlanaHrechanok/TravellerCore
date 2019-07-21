using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravellerCore.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        public string NameCountry { get; set; }
    }
}
