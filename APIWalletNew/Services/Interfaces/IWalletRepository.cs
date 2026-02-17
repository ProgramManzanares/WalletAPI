using APIWalletNew.Models;

namespace APIWalletNew.Services.Interfaces;

public interface IWalletRepository
{
    Task<User> GetUserByIdAsync(int idUser);
    Task AddAsync(User user);
}