using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravellerCore.Data;
using TravellerCore.Models;

namespace TravellerCore.Controllers
{
    public class HomeController : Controller
    {
        private TravelDBContext travelDB = new TravelDBContext();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ReadMore(int id)
        {
            Tour currentTour = travelDB.Tour.FirstOrDefault(t => t.Id == id);
            if (currentTour != null)
            {
                Hotel currentHotel = travelDB.Hotel.FirstOrDefault(h => h.Id == currentTour.IdHotel);
                Picture currentPicture = travelDB.Picture.FirstOrDefault(p => p.Id == currentHotel.IdPicture);
                
                ViewBag.NamePicture = currentPicture.NamePicture;
                ViewBag.Hotel = currentHotel;
                ViewBag.Cost = currentTour.Cost(currentHotel);

                LogicalTravelModel modelTravel = new LogicalTravelModel(id, currentHotel.NameHotel,
                    currentHotel.AboutHotel, (int)currentHotel.Price, currentTour.GetDateToString(), currentTour.AmountDay);

                return View(modelTravel);
            }
            else
            {
                ViewBag.Message = "Page is not found";
                return View("~/Views/Home/Message.cshtml");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id = 0)
        {
            ViewBag.Id = id;
            Tour currentTour = travelDB.Tour.FirstOrDefault(t => t.Id == id);
            if (currentTour != null)
            {
                Hotel currentHotel = travelDB.Hotel.FirstOrDefault(h => h.Id == currentTour.IdHotel);
                
                LogicalTravelModel modelTravel = new LogicalTravelModel(id, currentHotel.NameHotel,
                    currentHotel.AboutHotel, (int)currentHotel.Price, currentTour.GetDateToString(), currentTour.AmountDay);

                return View(modelTravel);
            }
            else
            {
                ViewBag.Message = "Page is not found";
                return View("~/Views/Home/Message.cshtml");
            }
        }

        [HttpPost]
        public string Upload(IFormFile uploadFile, int idTour)
        {
            string result = "";
            try
            {
                if (uploadFile != null || uploadFile.Length != 0)
                {

                    var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", uploadFile.FileName);
                    
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        uploadFile.CopyToAsync(stream);
                    }

                    Tour tour = travelDB.Tour.FirstOrDefault(t => t.Id == idTour);
                    Hotel hotel = travelDB.Hotel.FirstOrDefault(h => h.Id == tour.IdHotel);

                    Picture newPicture = new Picture
                    {
                        NamePicture = "../images/" + uploadFile.FileName,
                        IdHotel = hotel.Id
                    };
                    travelDB.Picture.Add(newPicture);
                    travelDB.SaveChanges();

                    hotel.IdPicture = newPicture.Id;
                    travelDB.SaveChanges();

                    result = "The picture is added!";
                }
                else
                {
                    result = "The picture is  NOT added!!";
                }
            }
            catch (Exception ex)
            {
                result = "The picture is  NOT added!!";
            }

            return result;
        }

        [HttpPost]
        public IActionResult Edit(int id, string dateArrival, int amountDay, string nameHotel, int price, string aboutHotel, IFormFile upload)
        {
            if(nameHotel != "" && price != 0 && aboutHotel != "" && amountDay != 0 && ModelState.IsValid)
            {
                Tour tour = travelDB.Tour.FirstOrDefault(t => t.Id == id);
                tour.DateArrival = DateTime.Parse(dateArrival);
                tour.AmountDay = amountDay;
                travelDB.SaveChanges();

                Hotel hotel = travelDB.Hotel.FirstOrDefault(h => h.Id == tour.IdHotel);
                hotel.NameHotel = nameHotel;
                hotel.Price = price;
                hotel.AboutHotel = aboutHotel;
                travelDB.SaveChanges();

                ViewBag.Message = "The tour edit! " + Upload(upload, id);
                return View("~/Views/Home/Message.cshtml");
            }
            else
            {

                ViewBag.Message = "Form`s fields are not filled!";
                return View(id);
            }
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string nameCountry, string nameHotel, string dateArrival, int price, string aboutHotel, int amountDay, IFormFile upload)
        {
            if (nameCountry != "" && nameHotel != "" && price != 0 && aboutHotel != "" && amountDay != 0 && ModelState.IsValid)
            {
                try
                {
                    int numCountry = travelDB.Country.Count(c => c.NameCountry == nameCountry);

                    if (numCountry == 0)
                    {
                        Country newCountry = new Country
                        {
                            NameCountry = nameCountry
                        };
                        travelDB.Country.Add(newCountry);
                        travelDB.SaveChanges();
                    }

                    int numHotel = travelDB.Hotel.Count(h => h.NameHotel == nameHotel);
                    Country country = travelDB.Country.FirstOrDefault(c => c.NameCountry == nameCountry);
                    int numIdCountry = travelDB.Hotel.Count(h => h.IdCountry == country.Id);

                    if (numHotel == 0 || numIdCountry == 0)
                    {
                        Hotel newHotel = new Hotel
                        {
                            IdCountry = country.Id,
                            IdPicture = 1,
                            NameHotel = nameHotel,
                            AboutHotel = aboutHotel,
                            Price = price
                        };
                        travelDB.Hotel.Add(newHotel);
                        travelDB.SaveChanges();
                    }

                    IEnumerable<Hotel> hotels = travelDB.Hotel.Where(h => h.IdCountry == country.Id);
                    Hotel hotelForTour = hotels.FirstOrDefault(h => h.NameHotel == nameHotel);

                    Tour newTour = new Tour
                    {
                        IdHotel = hotelForTour.Id,
                        DateArrival = DateTime.Parse(dateArrival),
                        AmountDay = amountDay
                    };
                    travelDB.Tour.Add(newTour);
                    travelDB.SaveChanges();

                    ViewBag.Message = "The tour add! " + Upload(upload, newTour.Id);
                }
                catch (ArgumentException ex)
                {
                    ViewBag.Message = ex.ToString();
                }
                catch (NullReferenceException ex)
                {
                    ViewBag.Message = ex.ToString();
                }

                return View("~/Views/Home/Message.cshtml");
            }
            else
            {
                ViewBag.Message = "Form`s fields are not filled!";
                return View();
            }  
        }

        [HttpGet]
        public string DeleteTour(int id = 0)
        {
            string result = "";

            Tour tour = travelDB.Tour.FirstOrDefault(t => t.Id == id);
            if (tour != null)
            {
                travelDB.Tour.Remove(tour);
                travelDB.SaveChanges();
                result = "This tour is delete";
            }
            else
            {
                result = "Page is not found";
            }

            return result;
        }

        public IActionResult About()
        {
            ViewBag.Message = "Svetlana Hrechanok";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "svetochkaufo@yandex.ru";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Message()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
