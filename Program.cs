
namespace CollegeStudentManagement
{
    using CollegeStudentManagement.Models;
    using Microsoft.EntityFrameworkCore;

    public class Program
    {

        public static void Main(string[] args)
        {
        
        var builder=WebApplication.CreateBuilder(args);
            var constr = builder.Configuration.GetConnectionString("conn");

            builder.Services.AddDbContext<DatabaseContext>(options =>options.UseSqlServer(constr));

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
                pattern: "{controller=Student}/{action=Profile}/{id?}");

            app.Run();
        }
    }
}
