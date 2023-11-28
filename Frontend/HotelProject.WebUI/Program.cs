using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;
using System;
using FluentValidation.AspNetCore;

namespace HotelProject.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<Context>();
            builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>();
            builder.Services.AddTransient<IValidator<CreateGuestDto>, CreateGuestValidator>();
            builder.Services.AddTransient<IValidator<UpdateGuestDto>, UpdateGuestValidator>();

            builder.Services.AddHttpClient();
            // Add services to the container.
            builder.Services.AddControllersWithViews().AddFluentValidation();
            builder.Services.AddAutoMapper(typeof(Program));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}