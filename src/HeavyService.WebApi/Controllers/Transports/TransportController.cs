using HeavyService.Application.Utils;
using HeavyService.Persistance.Dtos.Transports;
using HeavyService.Persistance.Validations.Transports;
using HeavyService.Service.Interfaces.Transports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HeavyService.WebApi.Controllers.Transports
{
    [Route("api/transports")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly ITransportService _service;
        private readonly int MaxPageSize = 30;
        public TransportController(ITransportService service)
        {
            this._service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new Paginationparams(page, MaxPageSize)));

        [HttpPut("{transportId}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateAsync(long transportId, [FromForm] TransportUpdateDto dto)
        {
            var updateValidator = new TransportUpdateValidator();
            var validationResult = updateValidator.Validate(dto);

            if (validationResult.IsValid) return Ok(await _service.UpdateAsync(transportId, dto));
            else return BadRequest(validationResult.Errors);
        }

        [HttpGet("count")]
        [AllowAnonymous]
        public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());

        [HttpGet("{transportId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(long transportId)
            => Ok(await _service.GetByIdAsync(transportId));

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAsyncs([FromForm] TransportCreateDto dto)
        {
            var Valid = new TransportCreateValidator();
            var result = Valid.Validate(dto);
            if (result.IsValid) return Accepted(await _service.CreateAsync(dto));
            else { return BadRequest(result.Errors); }
        }

        [HttpDelete("{transportId}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteAsync(long transportId)
            => Ok(await _service.DeleteAsync(transportId));
    }
}