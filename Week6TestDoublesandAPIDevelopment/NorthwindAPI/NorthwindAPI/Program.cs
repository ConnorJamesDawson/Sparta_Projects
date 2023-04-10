using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Data.Repositories;
using NorthwindAPI.Models;
using NorthwindAPI.Services;

namespace NorthwindAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var dbConnectionString = builder.Configuration["DefaultConnectionString"];

            builder.Services.AddDbContext<NorthwindContext>(
                opt => opt.UseSqlServer(dbConnectionString));

            builder.Services.AddControllers()
                .AddNewtonsoftJson(
                opt => opt.SerializerSettings
                .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            builder.Services.AddScoped(
                typeof(INorthwindRepository<>), 
                typeof(NorthwindRepository<>)); //When it comes accross a INorthwindRepos with the type of NorthwindContext it know to distinguish it from the one below

            builder.Services.AddScoped(
                typeof(INorthwindService<>), 
                typeof(NorthwindService<>));

            builder.Services.AddScoped<INorthwindRepository<Supplier>, SuppliersRepository>();

            builder.Services.AddScoped<INorthwindRepository<Category>, CategoryRepository>();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
/*            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();*/

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                /*                app.UseSwagger();
                                app.UseSwaggerUI();*/
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}