﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
}
