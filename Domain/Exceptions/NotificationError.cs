using Newtonsoft.Json;

namespace Domain.Exceptions;

public class NotificationError
{
    public IList<string> ErrorMessages { get; }

    [JsonIgnore]
    public bool IsInvalid => this.ErrorMessages.Any();

    public NotificationError()
    {
        ErrorMessages = new List<string>();
    }   
    
    public NotificationError(string message)
    {
        ErrorMessages = new List<string>{ message };
    }

    public void Add(string message)
    {
        this.ErrorMessages.Add(message);
    }
}

