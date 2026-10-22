namespace Meetly.DTO
{
    public record CreateUserRequest
    (
        string name,
        string password
    );

    public record CreateUserResponse(
        string Name,
        string Password
    );

    public record LoginRequest
    (
         string Username,
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
