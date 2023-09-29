using RefreshToken.Data;
using JWTAuthentication.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RefreshToken.Services;
using RefreshToken.DTO;

namespace RefreshToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authService.Register(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);
            SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);
            return Ok(result);
        }

        [HttpPost("Revoke-Token")]
        public async Task<IActionResult> RevokeToken([FromBody]RevokedTokenDTO dto)
        {
            var token = dto.Token ?? Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(token))
                return BadRequest("Token Is Required!");
      var result=await _authService.RevokeToken(token);
            if(!result)
                return BadRequest("Token In Valid!");
        return Ok();
        
        }
        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn([FromBody] LogInDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authService.LogIn(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);
            if (!string.IsNullOrEmpty(result.RefreshToken))
                SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

            return Ok(result);
        }
        //add refresh token to cookies
        private void SetRefreshTokenInCookie(string refreshToken,DateTime expires)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires= expires.ToLocalTime(),
            };                     // any key 
            Response.Cookies.Append("refreshToken",refreshToken,cookieOptions);
        }
    }
}
