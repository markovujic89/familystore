using FamilyStore.Entities;

namespace FamilyStore.Services.Interfaces;

public interface IJwtProvider
{
    string? GenerateTokenAsync(User user);
}