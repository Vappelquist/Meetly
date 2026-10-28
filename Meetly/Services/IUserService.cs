using Meetly.DTO;
using Meetly.Utils;

namespace Meetly.Services
{
    public interface IUserService
    {
        Task<ServiceResult<GetUserByIdResponse?>> GetUserByIdAsync(int id);
    }
}
