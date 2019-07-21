using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerCore.Data;
using TravellerCore.Models;

namespace TravellerCore.App_code
{
    public static class ListHelper
    {
        public static HtmlString GetTours(this IHtmlHelper html, Country country)
        {
            string result = "";
            using (TravelDBContext travelDB = new TravelDBContext())
            {
                try
                {
                    IEnumerable<Hotel> hotels = travelDB.Hotel.Where(h => h.IdCountry == country.Id);
                    IEnumerable<Tour> tours = travelDB.Tour;
                    IEnumerable<Picture> pictures = travelDB.Picture;
                    int num = 0;

                    foreach (Hotel h in hotels)
                    {
                        foreach (Tour t in tours)
                        {
                            if (t.IdHotel == h.Id)
                            {
                                num++;
                            }
                        }
                    }

                    if (num != 0)
                    {
                        foreach (Hotel hotel in hotels)
                        {
                            foreach (Tour tour in tours.Where(t => t.IdHotel == hotel.Id))
                            {
                                Picture currentPictures = pictures.FirstOrDefault(p => p.Id == hotel.IdPicture);
                                result += "" +
                                "<div class='col-sm-6 col-md-4'>" +
                                    "<div class='thumbnail'>" +
                                        "<img src = '" + currentPictures.NamePicture + "' alt='" + currentPictures.NamePicture + "'>" +
                                        "<div class='caption'>" +
                                            "<h4>" + hotel.NameHotel + "</h4>" +
                                            "<h5>" + tour.DateArrival.GetValueOrDefault().ToShortDateString() + "</h5>" +
                                            "<p>" + hotel.Price + "$</p>" +
                                            "<p>" + tour.AmountDay + " days</p>" +
                                            "<p>" + tour.Cost(hotel) + "$</p>" +
                                            "<div class='buttonsTour'>" +
                                                "<a href = '/Home/Edit?id=" + tour.Id + "' class='btn btn-primary'>Edit tour</a>" +
                                                "<button class='btn btn-danger deleteTour'>Delete</button>" +
                                                "<a href = '/Home/ReadMore?id=" + tour.Id + "' > READ MORE... </a>" +
                                                "<span class='idTour' style='display: none;'>" + tour.Id + "</span>" +
                                            "</div>" +
                                        "</div>" +
                                    "</div>" +
                                "</div>";
                            }
                        }
                    }
                    else
                    {
                        result += "" +
                                "<div class='col-sm-12'>" +
                                    "<div>" +
                                        "<h4>Tours are not in this country!</h4>" +
                                    "</div>" +
                                "</div>";
                    }
                }
                catch (ArgumentException ex)
                {
                    result = "Error" + ex.ToString();
                }
                catch (NullReferenceException ex)
                {
                    result = "Error" + ex.ToString();
                }
            }
                
            return new HtmlString(result);
        }

        public static HtmlString GetCountries(this IHtmlHelper html)
        {
            string result = "";
            using (TravelDBContext travelDB = new TravelDBContext())
            {
                IEnumerable<Country> countries = travelDB.Country;

                if (countries.Count() != 0)
                {
                    foreach (Country country in countries)
                    {
                        result += "" +
                        "<div class='country'>" +
                            "<h3>" + country.NameCountry + "</h3>" +
                        "</div>" +
                        "<div class='aboutCountryTours' style='display: none;'>" +
                            "<div class='row tour'>" +
                                GetTours(html, country) +
                            "</div>" +
                        "</div>";
                    }
                }
                else
                {
                    result = "Countries is not founded!";
                }
            }

            return new HtmlString(result);
        }

        public static HtmlString GetIndicator(this IHtmlHelper html, Hotel hotel)
        {
            string result = "";
            using (TravelDBContext travelDB = new TravelDBContext())
            {
                int number = 0;
                IEnumerable<Picture> pictures = travelDB.Picture.Where(p => p.IdHotel == hotel.Id);
                string classPicture = "active";

                if (pictures.Count() == 1)
                {
                    result = "<li data-target='#myCarousel' data-slide-to='" + number + "' class='" + classPicture + "'></ li > ";
                }
                else
                {
                    foreach (Picture picture in pictures)
                    {
                        if (picture.Id == hotel.IdPicture)
                        {
                            classPicture = "active";
                        }
                        else
                        {
                            classPicture = "";
                        }

                        result += "<li data-target='#myCarousel' data-slide-to='" + number + "' class='" + classPicture + "'></ li > ";
                        number++;
                    }
                }
            }
            
            return new HtmlString(result);
        }

        public static HtmlString GetCarousel(this IHtmlHelper html, Hotel hotel)
        {
            string result = "";
            using (TravelDBContext travelDB = new TravelDBContext())
            {
                IEnumerable<Picture> pictures = travelDB.Picture.Where(p => p.IdHotel == hotel.Id);
                string classPicture = "active";

                if (pictures.Count() == 1)
                {
                    result = "" +
                                "<div class='item " + classPicture + " slide'>" +
                                     "<img src = '" + pictures.FirstOrDefault().NamePicture + "' class='img_slide'>" +
                                "</div>";
                }
                else
                {
                    foreach (Picture picture in pictures)
                    {
                        if (picture.Id == hotel.IdPicture)
                        {
                            classPicture = "active";
                        }
                        else
                        {
                            classPicture = "";
                        }

                        result += "" +
                                "<div class='item " + classPicture + " slide'>" +
                                     "<img src = '" + picture.NamePicture + "' class='img_slide'>" +
                                "</div>";
                    }
                }
            }

            return new HtmlString(result);
        }

        public static HtmlString SelectImg(this IHtmlHelper html, int idTour)
        {
            string result = "";
            using (TravelDBContext travelDB = new TravelDBContext())
            {
                Tour tour = travelDB.Tour.FirstOrDefault(t => t.Id == idTour);
                Hotel hotel = travelDB.Hotel.FirstOrDefault(h => h.Id == tour.IdHotel);
                IEnumerable<Picture> pictures = travelDB.Picture.Where(p => p.IdHotel == hotel.Id);

                if (pictures.Count() != 0)
                {
                    foreach (Picture picture in pictures)
                    {
                        result += "" +
                            "<div class='img_select'>" +
                                     "<img src = '" + picture.NamePicture + "' class='img_slide'>" +
                                "</div>";
                    }
                }
                else
                {
                    result = "Pictures are not founded!";
                }
            }
            
            return new HtmlString(result);
        }
    }
}
