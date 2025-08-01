using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;
public class Bitumen
{
    [Column("BitumenId")]
    public int Id { get; set; }

    public int MaterialNumber { get; set; }

    [Required(ErrorMessage = "Bitumen name is required.")]
    [MaxLength(60, ErrorMessage = "Bitumen name cannot exceed 60 characters.")]
    public string Name { get; set; } = string.Empty;

    [ForeignKey(nameof(BitumenTank))]
    public int? BitumenTankId { get; set; }
    public BitumenTank? BitumenTank { get; set; }
}
