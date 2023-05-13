namespace Idk.Application.Exceptions.Common;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string entityName, int id) : base($"{entityName} with id: {id} is not found")
    {
        
    }
}