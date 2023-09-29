using JWTAuthentication.DTO;

namespace RefreshToken.Services
{
    public interface IAuthService
    {
        Task<AuthReturnDTO> Register(RegisterDTO model);
        Task<AuthReturnDTO> LogIn(LogInDTO model);
        Task<bool> RevokeToken(string token);
    }
}
