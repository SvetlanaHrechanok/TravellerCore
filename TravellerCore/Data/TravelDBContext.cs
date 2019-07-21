using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerCore.Models;

namespace TravellerCore.Data
{
    public class TravelDBContext : DbContext
    {
        public DbSet<Tour> Tour { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<Country> Country { get; set; }

        /*public TravelDBContext(DbContextOptions<TravelDBContext> options) : base(options)
        {
            Database.EnsureCreated(); //creat BD, if it is not.
        }*/
        public TravelDBContext()
        {
            Database.EnsureCreated(); //creat BD, if it is not.
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TravelCoreDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country[]
                {
                    new Country()
                    {
                        Id = 1,
                        NameCountry = "Italy"
                    },
                    new Country()
                    {
                        Id = 2,
                        NameCountry = "England"
                    },
                    new Country()
                    {
                        Id = 3,
                        NameCountry = "Egipt"
                    }
                });

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel[]
                {
                    new Hotel()
                    {
                        Id = 1,
                        IdCountry = 1,
                        IdPicture = 1,
                        NameHotel = "Venecia",
                        AboutHotel = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.",
                        Price = 75
                    },
                    new Hotel()
                    {
                        Id = 2,
                        IdCountry = 1,
                        IdPicture = 3,
                        NameHotel = "Rome",
                        AboutHotel = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.",
                        Price = 150
                    },
                    new Hotel()
                    {
                        Id = 3,
                        IdCountry = 2,
                        IdPicture = 4,
                        NameHotel = "Washington",
                        AboutHotel = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.",
                        Price = 100
                    },
                    new Hotel()
                    {
                        Id = 4,
                        IdCountry = 2,
                        IdPicture = 5,
                        NameHotel = "London",
                        AboutHotel = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.",
                        Price = 112
                    }

                });

            modelBuilder.Entity<Picture>().HasData(
                new Picture[]
                {
                    new Picture()
                    {
                        Id = 1,
                        NamePicture = "../images/legak.png",
                        IdHotel = 1
                    },
                    new Picture()
                    {
                        Id = 2,
                        NamePicture = "../images/serd.png",
                        IdHotel = 1
                    },
                    new Picture()
                    {
                        Id = 3,
                        NamePicture = "../images/legak.png",
                        IdHotel = 2
                    },
                    new Picture()
                    {
                        Id = 4,
                        NamePicture = "../images/serd.png",
                        IdHotel = 3
                    },
                    new Picture()
                    {
                        Id = 5,
                        NamePicture = "../images/serd.png",
                        IdHotel = 4
                    }
                });

            modelBuilder.Entity<Tour>().HasData(
                new Tour[]
                {
                    new Tour()
                    {
                        Id = 1,
                        IdHotel = 1,
                        DateArrival = DateTime.Parse("20.07.2019"),
                        AmountDay = 12
                    },
                    new Tour()
                    {
                        Id = 2,
                        IdHotel = 2,
                        DateArrival = DateTime.Parse("15.08.2019"),
                        AmountDay = 10
                    },
                    new Tour()
                    {
                        Id = 3,
                        IdHotel = 3,
                        DateArrival = DateTime.Parse("09.09.2019"),
                        AmountDay = 12
                    },
                    new Tour()
                    {
                        Id = 4,
                        IdHotel = 4,
                        DateArrival = DateTime.Parse("15.09.2019"),
                        AmountDay = 14
                    },
                    new Tour()
                    {
                        Id = 5,
                        IdHotel = 4,
                        DateArrival = DateTime.Parse("10.11.2019"),
                        AmountDay = 10
                    }
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
