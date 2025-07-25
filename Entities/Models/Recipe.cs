﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;
public class Recipe
{
    [Column("RecipeId")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Recipe name is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Recipe title is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Title is 60 characters")]
    public string? Title { get; set; }

    public DateTime Created { get; set; }

    public ICollection<Job>? Jobs { get; set; }
}
