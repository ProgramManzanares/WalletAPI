namespace APIWalletNew.Models.DTOs;

public class LoginRequest
{
    public string Name { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
}