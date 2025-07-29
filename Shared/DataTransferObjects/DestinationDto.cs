using Enums;

namespace Shared.DataTransferObjects;
public record DestinationDto(int Id, string Name, DestinationType DestinationType);