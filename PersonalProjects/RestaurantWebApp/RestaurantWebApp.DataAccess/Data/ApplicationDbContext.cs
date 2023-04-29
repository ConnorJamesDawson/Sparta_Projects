using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using RestaurantWebApp.Models;

namespace RestaurantWebApp.DataAccess.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Catagory { get; set; }
    public DbSet<FoodType> FoodType { get; set; }
    public DbSet<MenuItem> MenuItem { get; set; }
    public DbSet<ApplicationUser> ApplicationUser { get; set; }
    public DbSet<ShoppingCart> ShoppingCart { get; set; }
    public DbSet<OrderHeader> OrderHeader { get; set; }
    public DbSet<OrderDetails> OrderDetail { get; set; }
    public DbSet<Projects> Project { get; set; }
}
