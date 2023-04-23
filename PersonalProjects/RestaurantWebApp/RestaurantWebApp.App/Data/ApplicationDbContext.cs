using Microsoft.EntityFrameworkCore;
using RestaurantWebApp.App.Model;

namespace RestaurantWebApp.App.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Catagories { get; set; }
}
