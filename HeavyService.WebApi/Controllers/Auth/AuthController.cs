using HeavyService.Persistance.Dtos.Auth;
using HeavyService.Persistance.Validations;
using HeavyService.Persistance.Validations.Auth;
using HeavyService.Service.Interfaces.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HeavyService.WebApi.Controllers.Auth
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authservise;

        public AuthController(IAuthService authService)
        {
            _authservise = authService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync([FromForm] RegisterDto registerDto)
        {
            var validator = new RegisterValidator();
            var result = validator.Validate(registerDto);
            if (result.IsValid)
            {
                var serviseResult = await _authservise.RegisterAsync(registerDto);

                return Ok(new { serviseResult.Result, serviseResult.CachedMinutes });
            }
            else return BadRequest(result.Errors);
        }

        [HttpPost("register/send-code")]
        [AllowAnonymous]
        public async Task<IActionResult> SendCodeRegisterAsync(string email)
        {
            var result = EmailValidator.IsValid(email);
            if (result == false) return BadRequest("Email number is invalid!");

            var serviceResult = await _authservise.SendCodeForRegisterAsync(email);

            return Ok(new { serviceResult.Result, serviceResult.CachedVerificationMinutes });
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
        {
            var dto = new RegisterDto();
            var validator = new LoginValidator();
            var valResult = validator.Validate(loginDto);
            if (valResult.IsValid == false) return BadRequest(valResult.Errors);
            var serviceResult = await _authservise.LoginAsync(loginDto);

            return Ok(new { serviceResult.Result, serviceResult.Token });
        }

        [HttpPost("register/verify")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyRegisterAsync([FromBody] VerifyDto verifyDto)
        {
            var serviceResult = await _authservise.VerifyRegisterAsync(verifyDto.Email, verifyDto.Code);

            return Ok(new { serviceResult.Result, serviceResult.Token });
        }
    }
}