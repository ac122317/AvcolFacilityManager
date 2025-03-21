using AvcolFacilityManager.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AvcolFacilityManager.Models;

namespace AvcolFacilityManager.Areas.Identity.Data;

public class AvcolFacilityManagerDbContext : IdentityDbContext<AppUser>
{
    public AvcolFacilityManagerDbContext(DbContextOptions<AvcolFacilityManagerDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<AvcolFacilityManager.Models.Facility> Facility { get; set; } = default!;

public DbSet<AvcolFacilityManager.Models.Bookings> Bookings { get; set; } = default!;

public DbSet<AvcolFacilityManager.Models.Reviews> Reviews { get; set; } = default!;

public DbSet<AvcolFacilityManager.Areas.Identity.Data.AppUser> AppUser { get; set; } = default!;
}
