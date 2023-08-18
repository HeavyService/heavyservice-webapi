using HeavyService.Application.Utils;
using HeavyService.Persistance.Dtos.TransportComments;
using HeavyService.Persistance.Validations.TranportComments;
using HeavyService.Service.Interfaces.TransportComments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HeavyService.WebApi.Controllers.TransportComments
{
    [Route("api/comment")]
    [ApiController]
    public class TransportCommentController : ControllerBase
    {
        private readonly ITransportCommentService _service;
        private readonly int MaxPageSize = 30;
        public TransportCommentController(ITransportCommentService service)
        {
            this._service = service;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new Paginationparams(page, MaxPageSize)));

        [HttpPut("{commentId}")]

        public async Task<IActionResult> UpdateAsync(long commentId, [FromForm] TransportCommentDto dto)
        {
            var updateValidator = new TransportCommentValidator();
            var validationResult = updateValidator.Validate(dto);
            if (validationResult.IsValid) return Ok(await _service.UpdateAsync(commentId, dto));
            else return BadRequest(validationResult.Errors);
        }
        [HttpGet("count")]
        public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());

        [HttpGet("{commentId}")]
        public async Task<IActionResult> GetByIdAsync(long commentId)
            => Ok(await _service.GetByIdAsync(commentId));


        [HttpPost]
        public async Task<IActionResult> CreateAsyncs(long transportId, [FromForm] TransportCommentDto dto)
        {
            var Valid = new TransportCommentValidator();
            var result = Valid.Validate(dto);
            if (result.IsValid) return Ok(await _service.CreateAsync(transportId, dto));
            else { return BadRequest(result.Errors); }
        }
        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteAsync(long commentId)
            => Ok(await _service.DeleteAsync(commentId));

    }
}