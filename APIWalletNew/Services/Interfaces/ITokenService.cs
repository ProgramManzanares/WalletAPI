using APIWalletNew.Models;

namespace APIWalletNew.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}