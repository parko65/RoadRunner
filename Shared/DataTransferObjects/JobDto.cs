using Enums;

namespace Shared.DataTransferObjects;
public record JobDto(int Id, int JobNumber, DateTime Created, double Tonnage, JobStatus Status, RecipeDto? Recipe, DestinationDto Destination);
