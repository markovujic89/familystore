using FamilyStore.Entities;
using FamilyStore.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController:ControllerBase
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyController(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllCompanies()
    {
        var companies = await _companyRepository.GetAllAsync();
        return Ok(companies);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetCompany(Guid id)
    {
        var company = await _companyRepository.GetByIdAsync(id);
        return Ok(company);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateCompany(Company company)
    {
        await _companyRepository.AddAsync(company);
        return CreatedAtAction(nameof(GetCompany), new { id = company.Id }, company);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateCompany(Guid id, Company company)
    {
        if (id != company.Id)
        {
            return BadRequest();
        }
        await _companyRepository.UpdateAsync(company);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteCompany(Guid id)
    {
        await _companyRepository.DeleteAsync(id);
        return NoContent();
    }
}