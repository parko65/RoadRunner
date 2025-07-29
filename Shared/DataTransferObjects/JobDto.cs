using Enums;

namespace Shared.DataTransferObjects;
public record JobDto(int Id, int JobNumber, DateTime Created, JobStatus Status);
