using FamilyStore.Models;
using FamilyStore.Models.Login;
using FamilyStore.Repositories.Interface;

namespace FamilyStore.Services;

public class AuthService:IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<LoginResponse> GetAccessTokenAsync(LoginRequest request)
    {
        // Get User
        var user = await _userRepository.GetUserByEmailAsync(request.Email);

        if (user is null)
        {
            return new LoginResponse{ ErrorMessage = "Invalid Credentials"};
        }
        // Generate JWT
        
        // Return Token
        
        // https://www.youtube.com/watch?v=4cFhYUK8wnc&list=PLYpjLpq5ZDGtJOHUbv7KHuxtYLk1nJPw5
        throw new NotImplementedException();
    }
}