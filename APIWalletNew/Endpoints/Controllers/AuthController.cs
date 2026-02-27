using APIWalletNew.Data.Respositories;
using APIWalletNew.Models.DTOs;
using APIWalletNew.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIWalletNew.Endpoints.Controllers;

public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await _authService.RegisterUserAsync(request);
        return Ok();
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var token = await _authService.LoginAsync(request);
        return Ok(new { token });
    }
}