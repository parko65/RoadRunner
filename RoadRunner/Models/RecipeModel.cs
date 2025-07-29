namespace RoadRunner.Models;
public class RecipeModel
{    
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Title { get; set; }

    public int VersionNumber { get; set; }

    public DateTime Created { get; set; }

    public bool Valid { get; set; }

    public int BatchSize { get; set; }

    public bool FixedBatchSize { get; set; }

    public int MixTime { get; set; }

    public int MixTemperature { get; set; }

    public int UpperTemperatureDeviation { get; set; }
    public int LowerTemperatureDeviation { get; set; }
}
