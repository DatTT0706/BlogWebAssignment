using DataAccess.DTO;

namespace BlogWebAssignmentClient.Security
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, UserDTO user);
        bool ValidateToken(string key, string issuer, string token);
    }
}
