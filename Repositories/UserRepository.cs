using System.Transactions;
using FamilyStore.Data;
using FamilyStore.Entities;
using FamilyStore.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FamilyStore.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FamilyStoreDbContext _context;

    public UserRepository(FamilyStoreDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User userFroUpdate)
    {
        using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        try
        {
            var user = await _context.Users.FindAsync(userFroUpdate.Id);

            if (user is not null)
            {
                user.Email = userFroUpdate.Email;
                user.Name = userFroUpdate.Name;
                user.Age = userFroUpdate.Age;
                    
                _context.Entry(user).State = EntityState.Modified;
                    
                await _context.SaveChangesAsync();
            }

            transactionScope.Complete();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            transactionScope.Dispose();
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var userToDelete = await _context.Users.FindAsync(id);
        if (userToDelete != null)
        {
            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}