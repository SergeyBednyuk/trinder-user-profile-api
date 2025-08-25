namespace Trinder.UserProfile.Domain.Exceptions;

public class CantBePerformedException(string actionType, string resourceType) 
    : Exception($"Action Type: {actionType} cannot be performed on Resource: {resourceType}. Something went wrong.") { }
