using System.ComponentModel.DataAnnotations;

namespace JWTAuthentication.DTO
{
    public class RegisterDTO
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        
        public string Password { get; set; }
        public string Phone { get; set; }
        //public bool IsCitizen { get; set; } = true;
    }
}
