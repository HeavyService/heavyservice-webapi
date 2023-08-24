using HeavyService.Application.Utils;
using HeavyService.Persistance.Dtos.InstrumentComments;
using HeavyService.Persistance.Validations.InstrumentComments;
using HeavyService.Service.Interfaces.InstrumentComments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HeavyService.WebApi.Controllers.InstrumentComments
{
    [Route("api/instruments/comments")]
    [ApiController]
    public class InstrumentCommentController : ControllerBase
    {
        private readonly IInstrumentCommentService _service;
        private readonly int MaxPageSize = 30;
        public InstrumentCommentController(IInstrumentCommentService service)
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

        [HttpGet("{commentId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(long commentId)
            => Ok(await _service.GetByIdAsync(commentId));

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAsync([FromForm] InstrumentCommentCreateDto dto)
        {
            var Valid = new InstrumentCommentValidator();
            var result = Valid.Validate(dto);

            if (result.IsValid) return Ok(await _service.CreateAsync(dto));
            else { return BadRequest(result.Errors); }
        }

        [HttpDelete("{commentId}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteAsync(long commentId)
            => Ok(await _service.DeleteAsync(commentId));
    }
}