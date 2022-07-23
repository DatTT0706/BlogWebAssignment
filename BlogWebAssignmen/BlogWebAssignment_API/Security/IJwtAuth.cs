namespace BlogWebAssignment_API.Security
{
    public interface IJwtAuth
    {
        string Authentication(string username, string password);
    }
}
