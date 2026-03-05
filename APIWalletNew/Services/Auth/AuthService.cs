using APIWalletNew.Data.Interfaces;
using APIWalletNew.Models;
using APIWalletNew.Models.DTOs;
using APIWalletNew.Services.Interfaces;

namespace APIWalletNew.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IUserRepository _repository;
    private readonly ITokenService _tokenService;

    public AuthService(IUserRepository repository, ITokenService tokenService)
    {
        _repository = repository;
        _tokenService = tokenService;
    }

    public async Task RegisterUserAsync(RegisterRequest request)
    {
        var existingUser = await _repository.GetUserByEmailAsync(request.Email);

        if (existingUser != null)
        {
            throw new Exception("User already exists");
        }

        var user = new User
        {
            Name = request.Name,
            LastName = request.Lastname,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(user);
    }

    public async Task<string> LoginAsync(LoginRequest request)
    {
        var user = await _repository.GetUserByEmailAsync(request.Email);

        if (user is null)
        {
            throw new Exception("Invalid Credentials");
        }

        var isValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

        if (!isValid)
        {
            throw new Exception("Invalid Credentials");
        }

        return _tokenService.GenerateToken(user);
    }
}