namespace Trinder.UserProfile.Domain.Exceptions;

public class ProblemDuringSavingException(string actionType, string resourceType) 
    : Exception($"During {actionType} went wrong and one or more {resourceType} have not been saved in db") { }
