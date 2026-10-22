using Meetly.DTO;
using Meetly.Utils;

namespace Meetly.Services
{
    public interface IUserService
    {
        Task<ServiceResult<LoginResponse?>> LoginAsync(string username, string password);
        Task<ServiceResult<CreateUserResponse>> CreateAsync(CreateUserRequest userRequest);
        Task<ServiceResult<GetUserByIdResponse?>> GetUserByIdAsync(int id);
    }
}
