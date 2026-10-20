using Meetly.DTO;

namespace Meetly.Services
{
    public interface IUserService
    {
        Task<LoginRequest> LoginAsync(string username, string password);
    }
}
