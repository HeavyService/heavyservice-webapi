using HeavyService.Application.Utils;
using HeavyService.Persistance.Dtos.Users;
using HeavyService.Persistance.Validations.Users;
using HeavyService.Service.Interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HeavyService.WebApi.Controllers.Users
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserservice _service;
        private readonly int MaxPageSize = 30;
        public UserController(IUserservice service)
        {
            this._service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new Paginationparams(page, MaxPageSize)));

        [HttpGet("count")]
        [AllowAnonymous]
        public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());

        [HttpGet("{userId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(long userId)
            => Ok(await _service.GetByIdAsync(userId));

        [HttpDelete("{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(long userId)
            => Ok(await _service.DeleteAsync(userId));

        [HttpPut("{userId}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateAsync(long userId, [FromForm] UserUpdateDto dto)
        {
            var userValidator = new UserUpdateValidator();
            var result = userValidator.Validate(dto);

            if (result.IsValid) return Ok(await _service.UpdateAsync(userId, dto));
            else return BadRequest(result.Errors);
        }

        [HttpGet("search")]
        [AllowAnonymous]
        public async Task<IActionResult> SearchAsync(string search, [FromQuery] int page = 1)
            => Ok(await _service.SearchAsync(search, new Paginationparams(page, MaxPageSize)));
    }
}