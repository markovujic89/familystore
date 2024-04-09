using FamilyStore.Models.Login;

namespace FamilyStore.Services.Interfaces;

public interface IAuthService
{
    Task<LoginResponse> GetAccessTokenAsync(LoginRequest request);
}