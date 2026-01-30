using CarRentalBLL.Services;
using CarRentalBLL.Services.Interface;
using CarRentalDAL.Context;
using CarRentalDAL.Entities;
using CarRentalDAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CarRentalPL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ICarService,CarService>();
            builder.Services.AddScoped<ICaregotyService, CategoryService>();
            builder.Services.AddIdentity<AppUser, AppRole>()
               .AddEntityFrameworkStores<AppDBContext>();

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
                pattern: "{controller=test}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
