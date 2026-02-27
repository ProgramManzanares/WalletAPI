using APIWalletNew.Models;

namespace APIWalletNew.Services.Interfaces;

public interface IUserRepository
{
    Task<User> GetUserByIdAsync(int idUser);
    Task<User?>  GetUserByEmailAsync(string email);
    Task AddAsync(User user);
}