using APIWalletNew.Models;
using APIWalletNew.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIWalletNew.Data.Respositories;

public class WalletRepository : IWalletRepository
{
    private readonly ApplicationBdContext _context;

    public WalletRepository(ApplicationBdContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserByIdAsync(string idUser)
    {
        return await _context.Users
            .FirstAsync(w => w.Id == idUser);
    }

    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}