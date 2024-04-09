using FamilyStore.Data;
using FamilyStore.Entities;
using FamilyStore.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FamilyStore.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly FamilyStoreDbContext _context;

    public CompanyRepository(FamilyStoreDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<Company>> GetAllAsync()
    {
        return await _context.Companies.ToListAsync();
    }

    public async Task<Company> GetByIdAsync(Guid id)
    {
        return await _context.Companies.FindAsync(id);
    }

    public async Task AddAsync(Company company)
    {
        await _context.Companies.AddAsync(company);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Company company)
    {
        _context.Entry(company).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var companyToDelete = await _context.Companies.FindAsync(id);
        if (companyToDelete != null)
        {
            _context.Companies.Remove(companyToDelete);
            await _context.SaveChangesAsync();
        }
    }
}