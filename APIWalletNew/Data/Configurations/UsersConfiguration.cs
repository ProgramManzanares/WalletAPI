using APIWalletNew.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIWalletNew.Data.Configurations;

public class UsersConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(b => b.Name)
            .HasColumnName("name");

        builder.ToTable("users");

        builder.Property(e => e.LastName)
            .HasColumnName("last_name");
        
        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at");
        
        builder.Property(e => e.UpdatedAt)
            .HasColumnName("updated_at");
        
        builder.Property(e => e.Id)
            .HasColumnName("id");
        
        builder.Property(e => e.Email)
            .HasColumnName("email");
        
        builder.Property(e => e.PasswordHash)
            .HasColumnName("password_hash");
    }
}