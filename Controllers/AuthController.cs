using FamilyStore.Models.Login;
using FamilyStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FamilyStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController:ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost]
    public async Task<IActionResult> GetAccessToken([FromBody] LoginRequest loginRequest)
    {
        var response = await _authService.GetAccessTokenAsync(loginRequest);

        if (!String.IsNullOrEmpty(response.ErrorMessage))
        {
            return BadRequest(response.ErrorMessage);
        }
        
        return Ok(response);
    }
}