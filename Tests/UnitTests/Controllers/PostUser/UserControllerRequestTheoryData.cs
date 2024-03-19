using Xunit;

namespace UnitTests.Controllers.PostUser;

public class UserControllerRequestTheoryData : TheoryData<string>
{
    public UserControllerRequestTheoryData()
    {
        this.Add("{\"Username\":\"\",\"Email\":\"Email\",\"Password\":\"password\"}");
        this.Add("{\"Username\":\"   \",\"Email\":\"Email\",\"Password\":\"password\"}");
        this.Add("{\"Email\":\"Email\",\"Password\":\"password\"}");
        this.Add("{\"Username\":\"Username\",\"Email\":\"\",\"Password\":\"password\"}");
        this.Add("{\"Username\":\"Username\",\"Email\":\"    \",\"Password\":\"password\"}");
        this.Add("{\"Username\":\"Username\",\"Password\":\"password\"}");
        this.Add("{\"Username\":\"Username\",\"Email\":\"Email\",\"Password\":\"\"}");
        this.Add("{\"Username\":\"Username\",\"Email\":\"Email\",\"Password\":\"      \"}");
        this.Add("{\"Username\":\"Username\",\"Email\":\"Email\"}");
    }
}