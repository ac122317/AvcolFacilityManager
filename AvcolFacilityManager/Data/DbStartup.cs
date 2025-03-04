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

                if (Context.User.Any() || Context.Facility.Any() || Context.Bookings.Any() || Context.Reviews.Any())
                {
                    return;
                }

                var User = new User []
                {
                new User { LastName = "Doe", FirstName = "John", Email = "JohnDoe@gmail.com", Phone = "+640278321892"},
                new User { LastName = "Doe", FirstName = "Jane", Email = "JaneDoe@gmail.com", Phone = "+640229122832"},
                new User { LastName = "Smith", FirstName = "Alice", Email = "AliceSmith@gmail.com", Phone = "+64211234567"},
                new User { LastName = "Brown", FirstName = "Bob", Email = "BobBrown@gmail.com", Phone = "+64212345678"},
                new User { LastName = "Taylor", FirstName = "Emma", Email = "EmmaTaylor@gmail.com", Phone = "+64213456789"},
                new User { LastName = "Wilson", FirstName = "Liam", Email = "LiamWilson@gmail.com", Phone = "+64214567890"},
                new User { LastName = "Anderson", FirstName = "Olivia", Email = "OliviaAnderson@gmail.com", Phone = "+64215678901"},
                new User { LastName = "Thomas", FirstName = "Noah", Email = "NoahThomas@gmail.com", Phone = "+64216789012"},
                new User { LastName = "Harris", FirstName = "Sophia", Email = "SophiaHarris@gmail.com", Phone = "+64217890123"},
                new User { LastName = "Martin", FirstName = "Lucas", Email = "LucasMartin@gmail.com", Phone = "+64218901234"}

                };
                Context.User.AddRange(User);
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

                new Facility { FacilityName = "Performing Arts Centre", FacilityType = "Arts", Capacity = 700 },
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
                new Bookings { UserId = 1, FacilityId = 1, Date = new DateTime(2025, 9, 4), StartTime = new DateTime(2025, 9, 4, 9, 15, 0), EndTime = new DateTime(2025, 9, 4, 10, 30, 0)},
                new Bookings { UserId = 2, FacilityId = 2, Date = new DateTime(2025, 10, 4), StartTime = new DateTime(2025, 10, 4, 9, 15, 0), EndTime = new DateTime(2025, 10, 4, 10, 30, 0)},

                };
                Context.Bookings.AddRange(Bookings);
                Context.SaveChanges();

                var Reviews = new Reviews[]
                {
                new Reviews { BookingId = 1, Rating = 5, Comment = "Great experience with the facility, will book again!", DateCreated = new DateTime(2025, 4, 3, 11, 0, 0)},
                new Reviews { BookingId = 2, Rating = 5, Comment = "Very satisfied!", DateCreated = new DateTime(2025, 4, 3, 11, 0, 0)},
                };
                Context.Reviews.AddRange(Reviews);
                Context.SaveChanges();
            }
        }
    }
}

