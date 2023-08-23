using HeavyService.Application.Utils;
using HeavyService.Persistance.Dtos.Instruments;
using HeavyService.Persistance.Validations.Instruments;
using HeavyService.Service.Interfaces.Instruments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HeavyService.WebApi.Controllers.Instruments
{
    [Route("api/instruments")]
    [ApiController]
    public class InstrumentController : ControllerBase
    {
        private readonly IInstrumentService _service;
        private readonly int MaxPageSize = 30;

        public InstrumentController(IInstrumentService service)
        {
            this._service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new Paginationparams(page, MaxPageSize)));

        [HttpPut("{instrumentId}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateAsync(long instrumentId, [FromForm] InstrumentUpdateDto dto)
        {
            var updateValidator = new InstrumentUpdateValidator();
            var validationResult = updateValidator.Validate(dto);

            if (validationResult.IsValid) return Ok(await _service.UpdateAsync(instrumentId, dto));
            else return BadRequest(validationResult.Errors);
        }

        [HttpGet("count")]
        [AllowAnonymous]
        public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());

        [HttpGet("{instrumentId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(long instrumentId)
            => Ok(await _service.GetByIdAsync(instrumentId));

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAsyncs([FromForm] InstrumentCreateDto dto)
        {
            var Valid = new InstrumentCreateValidator();
            var result = Valid.Validate(dto);

            if (result.IsValid) return Ok(await _service.CreateAsync(dto));
            else { return BadRequest(result.Errors); }
        }

        [HttpDelete("{instrumentId}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteAsync(long instrumentid)
            => Ok(await _service.DeleteAsync(instrumentid));

        [HttpGet("search")]
        [AllowAnonymous]
        public async Task<IActionResult> SearchAsync(string search, [FromQuery] int page = 1)
            => Ok(await _service.SearchAsync(search, new Paginationparams(page, MaxPageSize)));
    }
}