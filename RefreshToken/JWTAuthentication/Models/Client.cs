using Microsoft.AspNetCore.Identity;

namespace RefreshToken.Models
{
    public class Client:IdentityUser
    {
    // This will be extra column in additional to the column in asp net User
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? ModifyDate { get; set; }
        public string Name { get; set; } = string.Empty;
        
        public string? Photo { get; set; }
        public bool IsAuthorized { get; set; }= true;
        public List<RefreshToken>?RefreshTokens { get; set; }

    }
}
