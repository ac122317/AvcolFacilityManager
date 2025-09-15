using AvcolFacilityManager.Areas.Identity.Data;
using AvcolFacilityManager.Models;
using NuGet.DependencyResolver;

namespace AvcolFacilityManager.DummyData
{
    public class DbStartup
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var Context = serviceScope.ServiceProvider.GetService<AvcolFacilityManagerDbContext>();

                //Statement to ensure the database is created when the project is run.
                Context.Database.EnsureCreated();

                //The if statement ensures that if there is any existing data amongst any of the models, the method will return to prevent the data being added again (thus being duplicated).

                if (Context.AppUser.Any() || Context.Facility.Any() || Context.Bookings.Any() || Context.Reviews.Any())
                {
                    return;
                }

                var AppUser = new AppUser []
                {
                new AppUser { LastName = "Doe", FirstName = "John", Email = "JohnDoe@gmail.com", Phone = "+640278321892"},
                new AppUser { LastName = "Doe", FirstName = "Jane", Email = "JaneDoe@gmail.com", Phone = "+640229122832"},
                new AppUser { LastName = "Smith", FirstName = "Alice", Email = "AliceSmith@gmail.com", Phone = "+64211234567"},
                new AppUser { LastName = "Brown", FirstName = "Bob", Email = "BobBrown@gmail.com", Phone = "+64212345678"},
                new AppUser { LastName = "Taylor", FirstName = "Emma", Email = "EmmaTaylor@gmail.com", Phone = "+64213456789"},
                new AppUser { LastName = "Wilson", FirstName = "Liam", Email = "LiamWilson@gmail.com", Phone = "+64214567890"},
                new AppUser { LastName = "Anderson", FirstName = "Olivia", Email = "OliviaAnderson@gmail.com", Phone = "+64215678901"},
                new AppUser { LastName = "Thomas", FirstName = "Noah", Email = "NoahThomas@gmail.com", Phone = "+64216789012"},
                new AppUser { LastName = "Harris", FirstName = "Sophia", Email = "SophiaHarris@gmail.com", Phone = "+64217890123"},
                new AppUser { LastName = "Martin", FirstName = "Lucas", Email = "LucasMartin@gmail.com", Phone = "+64218901234"},
                new AppUser { LastName = "Johnson", FirstName = "Mia", Email = "MiaJohnson@gmail.com", Phone = "+642212345678" },
                new AppUser { LastName = "Garcia", FirstName = "Ethan", Email = "EthanGarcia@gmail.com", Phone = "+642232456789" },
                new AppUser { LastName = "Martinez", FirstName = "Charlotte", Email = "CharlotteMartinez@gmail.com", Phone = "+642452678901" },
                new AppUser { LastName = "Roberts", FirstName = "Jack", Email = "JackRoberts@gmail.com", Phone = "+642532456789" },
                new AppUser { LastName = "Walker", FirstName = "Amelia", Email = "AmeliaWalker@gmail.com", Phone = "+642672890123" },
                new AppUser { LastName = "Lopez", FirstName = "William", Email = "WilliamLopez@gmail.com", Phone = "+642712890234" },
                new AppUser { LastName = "Gonzalez", FirstName = "Ava", Email = "AvaGonzalez@gmail.com", Phone = "+642722890345" },
                new AppUser { LastName = "Young", FirstName = "James", Email = "JamesYoung@gmail.com", Phone = "+642732890456" },
                new AppUser { LastName = "King", FirstName = "Grace", Email = "GraceKing@gmail.com", Phone = "+642742890567" },
                new AppUser { LastName = "Scott", FirstName = "Henry", Email = "HenryScott@gmail.com", Phone = "+642752890678" },
                new AppUser { LastName = "Adams", FirstName = "Zoe", Email = "ZoeAdams@gmail.com", Phone = "+642762890789" },
                new AppUser { LastName = "Baker", FirstName = "Owen", Email = "OwenBaker@gmail.com", Phone = "+642772890890" },
                new AppUser { LastName = "Nelson", FirstName = "Isabella", Email = "IsabellaNelson@gmail.com", Phone = "+642782890901" }

                };
                Context.AppUser.AddRange(AppUser);
                Context.SaveChanges();

                var Facility = new Facility[]
                {
                new Facility { FacilityName = "Halberg Gym", FacilityType = "Sports", Capacity = 1500 },
                new Facility { FacilityName = "Mills Gym", FacilityType = "Sports", Capacity = 200 },
                new Facility { FacilityName = "Turf", FacilityType = "Sports", Capacity = 1000 },
                new Facility { FacilityName = "Squash Court 1", FacilityType = "Sports", Capacity = 10 },
                new Facility { FacilityName = "Squash Court 2", FacilityType = "Sports", Capacity = 10 },
                new Facility { FacilityName = "Tennis Court 1", FacilityType = "Sports", Capacity = 6 },
                new Facility { FacilityName = "Tennis Court 2", FacilityType = "Sports", Capacity = 6 },
                new Facility { FacilityName = "Tennis Court 3", FacilityType = "Sports", Capacity = 6 },
                new Facility { FacilityName = "Tennis Court 4", FacilityType = "Sports", Capacity = 6 },
                new Facility { FacilityName = "Tennis Court 5", FacilityType = "Sports", Capacity = 6 },
                new Facility { FacilityName = "Netball Courts", FacilityType = "Sports", Capacity = 35 },
                new Facility { FacilityName = "Volleyball nets", FacilityType = "Sports", Capacity = 24 },

                new Facility { FacilityName = "PAC", FacilityType = "Arts", Capacity = 700 },
                new Facility { FacilityName = "Drama Room 1", FacilityType = "Arts", Capacity = 35 },
                new Facility { FacilityName = "Drama Room 2", FacilityType = "Arts", Capacity = 35 },
                new Facility { FacilityName = "Drama Room 3", FacilityType = "Arts", Capacity = 35 },
                new Facility { FacilityName = "Dance Studio 1", FacilityType = "Arts", Capacity = 30 },
                new Facility { FacilityName = "Dance Studio 2", FacilityType = "Arts", Capacity = 30 },
                new Facility { FacilityName = "Art Room 1", FacilityType = "Arts", Capacity = 35 },
                new Facility { FacilityName = "Art Room 2", FacilityType = "Arts", Capacity = 35 },
                new Facility { FacilityName = "Art Room 3", FacilityType = "Arts", Capacity = 35 },
                };
                Context.Facility.AddRange(Facility);
                Context.SaveChanges();

                var Bookings = new Bookings[]
                {
                new Bookings { AppUserId = AppUser[0].Id, FacilityId = 1, Date = new DateTime(2025, 11, 4), StartTime = new DateTime(2025, 11, 4, 9, 15, 0), EndTime = new DateTime(2025, 11, 4, 10, 30, 0)},
                new Bookings { AppUserId = AppUser[1].Id, FacilityId = 2, Date = new DateTime(2025, 11, 4), StartTime = new DateTime(2025, 11, 4, 9, 15, 0), EndTime = new DateTime(2025, 11, 4, 10, 30, 0)},
                new Bookings { AppUserId = AppUser[2].Id, FacilityId = 4, Date = new DateTime(2025, 11, 4), StartTime = new DateTime(2025, 11, 4, 10, 45, 0), EndTime = new DateTime(2025, 11, 4, 11, 30, 0)},
                new Bookings { AppUserId = AppUser[3].Id, FacilityId = 4, Date = new DateTime(2025, 11, 5), StartTime = new DateTime(2025, 11, 4, 10, 0, 0), EndTime = new DateTime(2025, 11, 4, 10, 30, 0)},
                new Bookings { AppUserId = AppUser[4].Id, FacilityId = 5, Date = new DateTime(2025, 11, 6), StartTime = new DateTime(2025, 11, 4, 11, 45, 0), EndTime = new DateTime(2025, 11, 4, 12, 30, 0)},
                new Bookings { AppUserId = AppUser[5].Id, FacilityId = 6, Date = new DateTime(2025, 11, 7), StartTime = new DateTime(2025, 11, 4, 9, 15, 0), EndTime = new DateTime(2025, 11, 4, 10, 30, 0)},
                new Bookings { AppUserId = AppUser[6].Id,FacilityId = 7, Date = new DateTime(2025, 11, 10), StartTime = new DateTime(2025, 11, 4, 12, 15, 0), EndTime = new DateTime(2025, 11, 4, 13, 0, 0)},
                new Bookings { AppUserId = AppUser[7].Id, FacilityId = 8, Date = new DateTime(2025, 11, 10), StartTime = new DateTime(2025, 11, 4, 13, 30, 0), EndTime = new DateTime(2025, 11, 4, 14, 30, 0)},

                };
                Context.Bookings.AddRange(Bookings);
                Context.SaveChanges();

                var Reviews = new Reviews[]
                {
                new Reviews { BookingId = 1, Rating = 5, Comment = "Great experience with the facility, will book again!", DateCreated = new DateTime(2025, 9, 3, 11, 0, 0)},
                new Reviews { BookingId = 2, Rating = 5, Comment = "Very satisfied!", DateCreated = new DateTime(2025, 9, 3, 11, 0, 0)},
                new Reviews { BookingId = 3, Rating = 5, Comment = "Had a very enjoyable time, the turf was spacious, just what I wanted!", DateCreated = new DateTime(2025, 9, 3, 11, 0, 0)},
                new Reviews { BookingId = 4, Rating = 5, Comment = "Lovely experience with the squash courts.", DateCreated = new DateTime(2025, 9, 3, 11, 0, 0)},
                new Reviews { BookingId = 7, Rating = 5, Comment = "Excellent.", DateCreated = new DateTime(2025, 9, 3, 11, 0, 0)},
                };
                Context.Reviews.AddRange(Reviews);
                Context.SaveChanges();
            }
        }
    }
}

