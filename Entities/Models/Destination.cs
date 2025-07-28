using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;
public class Destination
{
    [Column("DestinationId")]
    public int Id { get; set; }
}
