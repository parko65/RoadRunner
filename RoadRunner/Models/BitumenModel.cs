namespace RoadRunner.Models;
public class BitumenModel
{
    public int Id { get; set; }
    public int MaterialNumber { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? BitumenTankId { get; set; }
}
