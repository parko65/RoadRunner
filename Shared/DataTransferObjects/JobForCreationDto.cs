using Enums;

namespace Shared.DataTransferObjects;
public record JobForCreationDto(int JobNumber, DateTime Created, JobStatus Status, int RecipeId, int DestinationId);
