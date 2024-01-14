namespace RecordStoreDemo.Common.Exceptions;
public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(Guid entityId) : base($"Entity with Id: {entityId} could not found in the database.")
    {
    }
}