using System.ComponentModel.DataAnnotations;

namespace RoadRunner.Models;
public class AggregateForCreation
{
    [Required(ErrorMessage = "Material number is required.")]
    public int MaterialNumber { get; set; }

    [Required(ErrorMessage = "Aggregate name is required.")]
    [MaxLength(60, ErrorMessage = "Aggregate name cannot exceed 60 characters.")]
    public string Name { get; set; } = string.Empty;

    public int? HotBinId { get; set; }
}
