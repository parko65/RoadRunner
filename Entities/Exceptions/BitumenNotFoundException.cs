namespace Entities.Exceptions;
public sealed class BitumenNotFoundException : NotFoundException
{
    public BitumenNotFoundException(int bitumenId)
        : base($"Bitumen with id: {bitumenId} doesn't exist in the database.")
    {
    }
}
