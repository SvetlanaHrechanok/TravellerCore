﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravellerCore.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string NamePicture { get; set; }
        public Nullable<int> IdHotel { get; set; }
    }
}
