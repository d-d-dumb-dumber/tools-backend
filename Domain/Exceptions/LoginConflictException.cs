namespace Domain.Exceptions;

public class LoginConflictException(NotificationError notificationError) : Exception
{
    public readonly NotificationError notificationError = notificationError;

    public LoginConflictException(string errorMessage) : this(new NotificationError(errorMessage)) { }
    
}
