using Lounge.Common;

namespace Lounge.Domain
{
    public interface IUserService
    {
        Task<UserInfo>? Authenticate(string email, string password);
        Task Upload(FileStream stream, string fileName, string token);
        Task Insert();
    }
}
