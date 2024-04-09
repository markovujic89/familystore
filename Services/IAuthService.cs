using FamilyStore.Models;
using FamilyStore.Models.Login;

namespace FamilyStore.Services;

public interface IAuthService
{
    Task<LoginResponse> GetAccessTokenAsync(LoginRequest request);
}