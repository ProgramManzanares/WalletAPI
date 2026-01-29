using APIWalletNew.Models;

namespace APIWalletNew.Services.Interfaces;

public interface IWalletRepository
{
    Task<User> GetUserByIdAsync(string idUser);
    Task AddAsync(User user);
}