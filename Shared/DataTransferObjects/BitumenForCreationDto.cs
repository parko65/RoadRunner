using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;
public record BitumenForCreationDto
{
    [Required(ErrorMessage = "Material number is required.")]
    public int MaterialNumber { get; init; }

    [Required(ErrorMessage = "Bitumen name is required.")]
    [MaxLength(60, ErrorMessage = "Bitumen name cannot exceed 60 characters.")]
    public string Name { get; init; } = string.Empty;
    
    public int? BitumenTankId { get; init; }    
}
