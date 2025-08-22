namespace Trinder.UserProfile.Domain.Exceptions;

public class NotFoundException(string resourceType, string resourceIdentifier) : 
    Exception($"{resourceType} with this {resourceIdentifier} resource identifier does not exist.") { }
