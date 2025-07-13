using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AvcolFacilityManager.Areas.Identity.Data;
using AvcolFacilityManager.DummyData;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AvcolFacilityManagerDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AvcolFacilityManagerDbContextConnection' not found.");

builder.Services.AddDbContext<AvcolFacilityManagerDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<AvcolFacilityManagerDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

//Calling the SeedData method for the dummy data file.
DbStartup.SeedData(app);

//Code for adding the Admin Role.
using (var scope = app.Services.CreateScope())
{
    var AvcolFacilityRoleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    if (!await AvcolFacilityRoleManager.RoleExistsAsync("Admin"))
        await AvcolFacilityRoleManager.CreateAsync(new IdentityRole("Admin"));
}

using (var scope = app.Services.CreateScope())
{
    var AvcolFacilityUserManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

    string adminEmail = "admin@avcol.school.nz";
    string adminPassword = "TestAdmin123!";

    if (await AvcolFacilityUserManager.FindByEmailAsync(adminEmail) == null)
    {
        var user = new AppUser();
        user.UserName = adminEmail;
        user.Email = adminEmail;
        user.FirstName = "Test";
        user.LastName = "Admin";
        user.Phone = "+640212345678";

        await AvcolFacilityUserManager.CreateAsync(user, adminPassword);
        await AvcolFacilityUserManager.AddToRoleAsync(user, "Admin");
    }
}

app.Run();
