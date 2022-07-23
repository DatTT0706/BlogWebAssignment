using DataAccess.DTO;

namespace BlogWebAssignmentAdmin.Security
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, UserDTO user);
        bool ValidateToken(string key, string issuer, string token);
    }
}
