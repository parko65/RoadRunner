using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;
public class Aggregate
{
    [Column("AggregateId")]
    public int Id { get; set; }

    public int MaterialNumber { get; set; }

    [Required(ErrorMessage = "Aggregate name is required.")]
    [MaxLength(60, ErrorMessage = "Aggregate name cannot exceed 60 characters.")]
    public string Name { get; set; } = string.Empty;

    [ForeignKey(nameof(HotBin))]
    public int? HotBinId { get; set; }
    public HotBin? HotBin { get; set; }
}
