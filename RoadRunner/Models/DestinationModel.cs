using Enums;

namespace RoadRunner.Models;
public class DestinationModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DestinationType DestinationType { get; set; }
}
