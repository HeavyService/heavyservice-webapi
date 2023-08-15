using HeavyService.Application.Utils;
using HeavyService.Persistance.Dtos.InstrumentComments;
using HeavyService.Persistance.Validations.InstrumentComments;
using HeavyService.Service.Interfaces.InstrumentComments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeavyService.WebApi.Controllers.InstrumentComment
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentCommentController : ControllerBase
    {
        private readonly IInstrumentCommentService _service;
        private readonly int MaxPageSize = 30;
        public InstrumentCommentController(IInstrumentCommentService service)
        {
            this._service = service;
        }
        [HttpGet("GetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new Paginationparams(page, MaxPageSize)));

        [HttpPut("{instrumentCommentId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(long instrumentcommentId, [FromForm] InstrumentCommentCreateDto dto)
        {
            var updateValidator = new InstrumentCommentValidator();
            var validationResult = updateValidator.Validate(dto);
            if (validationResult.IsValid) return Ok(await _service.UpdateAsync(instrumentcommentId, dto));
            else return BadRequest(validationResult.Errors);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());

        [HttpGet("{getbyid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByIdAsync(long getbyid)
            => Ok(await _service.GetByIdAsync(getbyid));


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAsyncs([FromForm] InstrumentCommentCreateDto dto)
        {
            var Valid = new InstrumentCommentValidator();
            var result = Valid.Validate(dto);
            if (result.IsValid) return Accepted(await _service.CreateAsync(dto));
            else { return BadRequest(result.Errors); }
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(long instrumentcommenttid)
            => Ok(await _service.DeleteAsync(instrumentcommenttid));

    }
}