using FamilyStore.Models.Login;
using FamilyStore.Repositories.Interface;
using FamilyStore.Services.Interfaces;

namespace FamilyStore.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;

    public AuthService(IUserRepository userRepository, IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }

    public async Task<LoginResponse> GetAccessTokenAsync(LoginRequest request)
    {
        // Get User
        var user = await _userRepository.GetUserByEmailAsync(request.Email);

        if (user is null)
        {
            return new LoginResponse { ErrorMessage = "Invalid Credentials" };
        }

        // Generate JWT
        var token = _jwtProvider.GenerateTokenAsync(user);

        // Return Token
        return new LoginResponse { Token = token };
    }
}