using DotnetOrderAI.Dtos;

namespace DotnetOrderAI.Services.Authentication
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto request);
        Task<string> LoginAsync(LoginDto request);
    }
}
