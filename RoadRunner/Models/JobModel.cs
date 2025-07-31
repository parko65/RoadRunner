using Enums;

namespace RoadRunner.Models;
public class JobModel
{
    public int Id { get; set; }
    public int JobNumber { get; set; }
    public DateTime Created { get; set; }
    public double Tonnage { get; set; }
    public JobStatus Status { get; set; }
    public int RecipeId { get; set; }
    public RecipeModel? Recipe { get; set; }
    public int DestinationId { get; set; }
    public DestinationModel? Destination { get; set; }
}