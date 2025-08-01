using System.ComponentModel.DataAnnotations;

namespace RoadRunner.Models;
public class JobForCreation
{
    [Range(1, 62000, ErrorMessage = "Job number must be between 1 and 62000")]
    public string JobNumber { get; set; } = "0";

    [Range(0.5, 320, ErrorMessage = "Job tonnage must be between 0.5 and 320")]
    public string Tonnage { get; set; } = "0.0";
    
    public int RecipeId { get; set; }

    [Required(ErrorMessage = "Destination ID is required")]
    public string DestinationId { get; set; } = string.Empty;
}