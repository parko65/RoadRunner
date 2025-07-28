namespace Shared.DataTransferObjects;
public record RecipeDto
    (
    int Id,
    string Name,
    string Title,
    int VersionNumber,
    DateTime Created,
    bool Valid,
    int BatchSize,
    bool FixedBatchSize,
    int MixTime,
    int MixTemperature,
    int UpperTemperatureDeviation,
    int LowerTemperatureDeviation
    );
