using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApp.Models;

public class MenuItem
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageURL { get; set; }
    [Range(0.5, 150, ErrorMessage = "The price should be at least £0.50p and at most £150")]
    public double Price { get; set; }
    [Display(Name= "Food Type")]
    public int FoodTypeId { get; set; }
    [ForeignKey("FoodTypeId")]
    public FoodType FoodType { get; set; }
    [Display(Name = "Category")]
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }

}
