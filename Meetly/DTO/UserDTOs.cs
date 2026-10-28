using System.ComponentModel.DataAnnotations;

namespace Meetly.DTO
{
    public record CreateUserRequest
    (
        [Required]
        string name,
        [Required]
        string password
    );

    public record CreateUserResponse(
        [Required]
        string Name,
        [Required]
        string Password
    );

    public record LoginRequest
    (
         [Required]
         string Username,
         [Required]
         string Password
    );

    public record LoginResponse
    (
        string Username,
        int id
    );

    public record UserMeets(
        int id,
        string Title,
        string Description,
        string Place,
        DateTime Time,
        int MaxCapacity
    );

    public record GetUserByIdResponse(
        int Id,
        string Name,
        List<UserMeets> Meetups
    );
}
