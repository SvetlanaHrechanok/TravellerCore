﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravellerCore.Models
{
    public class Tour
    {
        public int Id { get; set; }
        public Nullable<int> IdHotel { get; set; }
        public Nullable<System.DateTime> DateArrival { get; set; }
        public Nullable<int> AmountDay { get; set; }
        public Nullable<decimal> Cost(Hotel hotel)
        {
            Nullable<decimal> cost = 0;
            cost = hotel.Price * this.AmountDay;
            return cost;
        }
        public string GetDateToString()
        {
            string dateStr = "";

            int year = DateArrival.GetValueOrDefault().Year;
            int month = DateArrival.GetValueOrDefault().Month;
            int day = DateArrival.GetValueOrDefault().Day;
            string monthStr = "";
            string dayStr = "";

            if (month < 10)
            {
                monthStr = "0" + month.ToString();
            }
            else
            {
                monthStr = month.ToString();
            }

            if (day < 10)
            {
                dayStr = "0" + day.ToString();
            }
            else
            {
                dayStr = day.ToString();
            }

            dateStr = year.ToString() + "-" + monthStr + "-" + dayStr;

            return dateStr;
        }
    }
}
