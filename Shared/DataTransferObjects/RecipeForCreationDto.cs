namespace Shared.DataTransferObjects;
public record RecipeForCreationDto
    (    
    string Name,
    string Title,
    int VersionNumber,    
    bool Valid,
    int BatchSize,
    bool FixedBatchSize,
    int MixTime,
    int MixTemperature,
    int UpperTemperatureDeviation,
    int LowerTemperatureDeviation
    );

// The Created property is not included in the record as it is typically set by the server when the recipe is created.