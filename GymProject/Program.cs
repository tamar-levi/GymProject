using DAL.Interface;
using DAL.Data;
using AutoMapper;
//using AutoMapper.Extensions.Microsoft.DependencyInjection;
using DAL.DTO;
using DAL.Profiles;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using MODELS.Models;
using System.Globalization;
namespace GymProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(CultureInfo.InvariantCulture);

            });
            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            // Add DbContext
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDataBase")));
            // builder.Services.AddDbContext<BooksContext>(op => op.UseSqlServer("Data Source=DESKTOP-UE6H0IP;Initial Catalog=Books;Integrated Security=SSPI;Trusted_Connection=True;"));
            builder.Services.AddScoped<IFitnessMachines, FitnessMachinesData>();
            builder.Services.AddScoped<IGroup, GroupData>();
            builder.Services.AddScoped<IGuide, GuidData>();
            builder.Services.AddScoped<ISchedules, SchedulesData>();
            builder.Services.AddScoped<IUser, UsersData>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}