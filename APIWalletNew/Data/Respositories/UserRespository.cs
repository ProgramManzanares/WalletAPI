using APIWalletNew.Models;
using APIWalletNew.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIWalletNew.Data.Respositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationBdContext _context;

    public UserRepository(ApplicationBdContext context)
    {
        _context = context;
    }

     public async Task<User> GetUserByIdAsync(int idUser)
     {
         return await _context.Users
             .FirstAsync(w => w.Id == idUser);
     }

     public async Task<User?> GetUserByEmailAsync(string email)
     {
         return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
     }
     public async Task AddAsync(User user)
     {
         _context.Users.Add(user);
        await _context.SaveChangesAsync();
     }
}