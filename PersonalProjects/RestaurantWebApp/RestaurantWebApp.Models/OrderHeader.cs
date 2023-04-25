﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApp.Models;

public class OrderHeader
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    [ValidateNever]
    public ApplicationUser AppUser { get; set; }
    [Required]
    public DateTime OrderDate { get; set; }
    [Required]
    [DisplayFormat(DataFormatString = "{0:C}")]
    [Display(Name = "Order Total")]
    public double OrderTotal { get; set; }
    [Required]
    [Display(Name = "Pick Up Time")]
    public DateTime PickUpTime { get; set; }
}
