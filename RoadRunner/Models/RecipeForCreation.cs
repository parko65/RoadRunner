using System.ComponentModel.DataAnnotations;

namespace RoadRunner.Models;
public sealed class RecipeForCreation
{
    [Required(ErrorMessage = "Recipe name is a required field.")]
    [MaxLength(20, ErrorMessage = "Name must be less than 20 characters")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Recipe title is a required field.")]
    [MaxLength(30, ErrorMessage = "Name must be less than 20 characters")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Recipe version is a required field.")]
    [Range(1, 100, ErrorMessage = "Version number must be between 1 and 100")]
    public string VersionNumber { get; set; } = "1";
    public bool Valid { get; set; } = true;

    [Required(ErrorMessage = "Recipe batch size is a required field.")]
    [Range(1, 3000, ErrorMessage = "Version number must be between 1 and 3000")]
    public string BatchSize { get; set; } = "3000";
    public bool FixedBatchSize { get; set; }

    [Required(ErrorMessage = "Recipe mix time is a required field.")]
    [Range(1, 30, ErrorMessage = "Mix time must be between 1 and 30")]
    public string MixTime { get; set; } = "25";

    [Required(ErrorMessage = "Recipe mix temperature is a required field.")]
    [Range(1, 300, ErrorMessage = "Mix temperature must be between 1 and 300")]
    public string MixTemperature { get; set; } = "0";
    public int UpperTemperatureDeviation { get; set; }
    public int LowerTemperatureDeviation { get; set; }
}
