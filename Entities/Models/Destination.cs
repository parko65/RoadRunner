using Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;
public class Destination
{
    [Column("DestinationId")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is a required field.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Type is a required field.")]
    public DestinationType DestinationType { get; set; }

    public ICollection<Job>? Jobs { get; set; }
}
