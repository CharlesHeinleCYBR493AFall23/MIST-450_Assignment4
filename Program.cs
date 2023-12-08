using CarsApp_450.Data;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        //Get information regarding connection string and store it in a variable
        var connectionString = builder.Configuration.GetConnectionString("CarsDBConnection");

        //Adds the DBcontext class to the services using sqlserver as default database management system. and the connection string that was grabbed in the previous statement
        builder.Services.AddDbContext<CarsDBContext>(options => options.UseSqlServer(connectionString));

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
            pattern: "{controller=Car}/{action=Index}/{id?}");

        app.Run();
    }
}
