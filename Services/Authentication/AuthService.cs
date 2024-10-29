using DotnetOrderAI.Dtos;
using DotnetOrderAI.Models;
using FirebaseAdmin.Auth;

namespace DotnetOrderAI.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> LoginAsync(LoginDto request)
        {
            var credentials = new
            {
                request.Email,
                request.Password,
                returnSecureToken = true,
            };
            var response = await _httpClient.PostAsJsonAsync("", credentials);

            var authFirebaseObject = await response.Content.ReadFromJsonAsync<AuthFirebase>();

            return authFirebaseObject!.IdToken!;
        }

        public async Task<string> RegisterAsync(RegisterDto request)
        {
            var userArgs = new UserRecordArgs
            {
                Email = request.Email,
                Password = request.Password,
            };
            var user = await FirebaseAuth.DefaultInstance.CreateUserAsync(userArgs);
            return user.Uid;
        }

    }
}
