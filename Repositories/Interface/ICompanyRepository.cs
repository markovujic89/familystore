using FamilyStore.Entities;

namespace FamilyStore.Repositories.Interface;

public interface ICompanyRepository
{
    Task<IEnumerable<Company>> GetAllAsync();
    Task<Company> GetByIdAsync(Guid id);
    Task AddAsync(Company company);
    Task UpdateAsync(Company company);
    Task DeleteAsync(Guid id);
}