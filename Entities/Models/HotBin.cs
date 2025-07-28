using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;
public class HotBin
{
    [Column("HotBinId")]
    public int Id { get; set; }

    public string? Name { get; set; }

    public Aggregate? Aggregate { get; set; }

    public ICollection<RecipeHotBin>? RecipeHotBins { get; set; }
}
