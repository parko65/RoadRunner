namespace Entities.Exceptions;
public sealed class AggregateNotFoundException : NotFoundException
{
    public AggregateNotFoundException(int aggregateId)
        : base($"Aggregate with id: {aggregateId} doesn't exist in the database.")
    {
    }
}
