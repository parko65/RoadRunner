using Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;
public class Job
{
    [Column("JobId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Job number is a required field.")]
    public int JobNumber { get; set; }

    public DateTime Created { get; set; }

    public JobStatus Status { get; set; }

    [ForeignKey(nameof(Recipe))]
    public int RecipeId { get; set; }
    public Recipe? Recipe { get; set; }

    [ForeignKey(nameof(Destination))]
    public int DestinationId { get; set; }
    public Destination? Destination { get; set; }
}
