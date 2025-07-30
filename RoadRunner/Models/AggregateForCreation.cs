using System.ComponentModel.DataAnnotations;

namespace RoadRunner.Models;
public class AggregateForCreation
{
    [Range(1001, 1010, ErrorMessage = "Material number is required and must be between 1001 and 1010.")]
    public string? MaterialNumber { get; set; }

    [Required(ErrorMessage = "Aggregate name is required.")]
    [MaxLength(60, ErrorMessage = "Aggregate name cannot exceed 60 characters.")]
    public string Name { get; set; } = string.Empty;

    public int? HotBinId { get; set; }
}
