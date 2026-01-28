using APIWalletNew.Models;
using Microsoft.EntityFrameworkCore;

namespace APIWalletNew.Services.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; set; }    
}