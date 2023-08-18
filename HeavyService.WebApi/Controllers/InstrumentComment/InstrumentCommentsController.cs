using HeavyService.Application.Utils;
using HeavyService.Persistance.Dtos.InstrumentComments;
using HeavyService.Persistance.Validations.InstrumentComments;
using HeavyService.Service.Interfaces.InstrumentComments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HeavyService.WebApi.Controllers.InstrumentComment
{
    [Route("api/comments")]
    [ApiController]
    public class InstrumentCommentsController : ControllerBase
    {
        private readonly IInstrumentCommentService _service;
        private readonly int MaxPageSize = 30;
        public InstrumentCommentsController(IInstrumentCommentService service)
        {
            this._service = service;
        }
        [HttpGet("{commentid}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new Paginationparams(page, MaxPageSize)));

        [HttpPut("{commentId}")]
        public async Task<IActionResult> UpdateAsync(long instrumentId, [FromForm] InstrumentCommentCreateDto dto)
        {
            var updateValidator = new InstrumentCommentValidator();
            var validationResult = updateValidator.Validate(dto);
            if (validationResult.IsValid) return Ok(await _service.UpdateAsync(instrumentId, dto));
            else return BadRequest(validationResult.Errors);
        }
        [HttpGet("{count}")]
        public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());

        [HttpGet("{commentId}")]
        public async Task<IActionResult> GetByIdAsync(long commentId)
            => Ok(await _service.GetByIdAsync(commentId));


        [HttpPost("commentId")]
        public async Task<IActionResult> CreateAsync(long instrumentId, [FromForm] InstrumentCommentCreateDto dto)
        {
            var Valid = new InstrumentCommentValidator();
            var result = Valid.Validate(dto);
            if (result.IsValid) return Ok(await _service.CreateAsync(instrumentId, dto));
            else { return BadRequest(result.Errors); }
        }
        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteAsync(long commentId)
            => Ok(await _service.DeleteAsync(commentId));
    }
}
