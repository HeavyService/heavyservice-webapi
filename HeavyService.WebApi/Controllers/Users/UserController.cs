using HeavyService.Application.Utils;
using HeavyService.Persistance.Dtos.Users;
using HeavyService.Service.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace HeavyService.WebApi.Controllers.Users
{
    [Route("api/user")]
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

        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new Paginationparams(page, MaxPageSize)));


        [HttpGet("count")]
        public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByIdAsync(long userId)
            => Ok(await _service.GetByIdAsync(userId));


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] UserCreateDto dto)
            => Ok(await _service.CreateAsync(dto));

        [HttpDelete("{userId}")]

        public async Task<IActionResult> DeleteAsync(long userId)
            => Ok(await _service.DeleteAsync(userId));
    }
}
