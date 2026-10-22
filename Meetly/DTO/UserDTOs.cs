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

        public record GetUserByIdResponse(
            int Id,
            string Name
        );
}
