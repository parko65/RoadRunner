namespace RoadRunner.Models;
public class AggregateModel
{
    public int Id { get; set; }
    public int MaterialNumber { get; set; }    
    public string Name { get; set; } = string.Empty;
    public int? HotBinId { get; set; }
}
