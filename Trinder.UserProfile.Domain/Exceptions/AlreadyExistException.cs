namespace Trinder.UserProfile.Domain.Exceptions;

public class AlreadyExistException(string resourceType, string resourceIdentifier) :
    Exception($"{resourceType} with this {resourceIdentifier} resource identifier already exists.") { }
