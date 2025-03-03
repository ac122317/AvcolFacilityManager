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
                new User { LastName = "Doe", FirstName = "Jane", Email = "JaneDoe@gmail.com", Phone = "+640229122832"}

                };
                Context.User.AddRange(User);
                Context.SaveChanges();

                var Facility = new Facility[]
                {
                new Facility { FacilityName = "Halberg Gym", FacilityType = "Gym", Capacity = 1000 },
                new Facility { FacilityName = "Mills Gym", FacilityType = "Gym", Capacity = 200 },

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

