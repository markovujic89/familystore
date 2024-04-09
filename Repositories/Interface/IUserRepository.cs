using FamilyStore.Entities;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace FamilyStore.Repositories.Interface;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> GetByIdAsync(Guid id);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid id);
    
    Task<User> GetUserByEmailAsync(string email);
}