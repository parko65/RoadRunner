using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;
public class BitumenTank
{
    [Column("BitumenTankId")]
    public int Id { get; set; }

    public string? Name { get; set; }

    public Bitumen? Bitumen { get; set; }

    public ICollection<RecipeBitumenTank>? RecipeBitumenTanks { get; set; }
}
