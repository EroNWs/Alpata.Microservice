using Meeting.Business.Interfaces.Services;
using Meeting.Dtos.MeetingCrudDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meeting.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingService _meetingService;
        public MeetingController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "MeetingFullPermission")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _meetingService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet("getall")]
        [Authorize(Policy = "MeetingFullPermission")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _meetingService.GetAllAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost("createmeeting")]
        [Authorize(Policy = "MeetingFullPermission")]
        public async Task<IActionResult> CreateMeeting([FromForm] MeetingCreateDto meetingCreateDto, [FromForm] IFormFile document)
        {
            if (document != null)
            {
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "documents");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(document.FileName);
                var filePath = Path.Combine(uploadsFolderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await document.CopyToAsync(stream);
                }

                meetingCreateDto.DocumentPath = $"/documents/{fileName}";
            }


            var result = await _meetingService.AddAsync(meetingCreateDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }


            return CreatedAtAction(nameof(GetByIdAsync), new { id = result.Data.Id }, result.Data);
        }


        [HttpPut("{id}")]
        [Authorize(Policy = "MeetingFullPermission")]
        public async Task<IActionResult> Update(Guid id, [FromForm] MeetingUpdateDto meetingUpdateDto, IFormFile document)
        {
            if (id != meetingUpdateDto.Id)
            {
                return BadRequest("ID mismatch");
            }

            if (document != null)
            {
                // Dosya güncelleme işlemleri burada gerçekleştirilecek
            }

            var result = await _meetingService.UpdateAsync(meetingUpdateDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "MeetingFullPermission")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _meetingService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }



    }
}
