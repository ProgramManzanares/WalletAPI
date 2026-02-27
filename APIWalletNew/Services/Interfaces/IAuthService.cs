using APIWalletNew.Models;
using APIWalletNew.Models.DTOs;

namespace APIWalletNew.Services.Interfaces;

public interface IAuthService
{
    Task RegisterUserAsync(RegisterRequest request);
    Task<string> LoginAsync(LoginRequest request);
}