﻿using System.ComponentModel.DataAnnotations;

namespace MarketPlace.MVC.Models
{
    public class CreateCategoryInputModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Category name")]
        public string Name { get; set; }

        [MaxLength(250)]
        [DataType(DataType.Text)]
        [Display(Name = "Category description")]
        public string? Description { get; set; }
    }
}
