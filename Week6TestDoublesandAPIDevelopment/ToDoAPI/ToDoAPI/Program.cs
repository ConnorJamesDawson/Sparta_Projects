
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

namespace ToDoAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
/*        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();*/

        builder.Services.AddDbContext<ToDoContext>(
            opt => opt.UseInMemoryDatabase("ToDoList"));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            //app.UseSwagger();
            //app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }
        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
        
    }
}