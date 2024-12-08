using CV_Manager.Services.DTOs;
using CV_Manager.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CV_Manager.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceInformationController : ControllerBase
    {
        private readonly ExperienceInformationService _experienceInformationService;

        public ExperienceInformationController(ExperienceInformationService experienceInformationService)
        {
            _experienceInformationService = experienceInformationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExperienceInformationDto>>> GetAllExperienceInfo()
        {
            var experienceInfo = await _experienceInformationService.GetAllExperienceInfoAsync();
            return Ok(experienceInfo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExperienceInformationDto>> GetExperienceInfoById(int id)
        {
            var experienceInfo = await _experienceInformationService.GetExperienceInfoByIdAsync(id);
            if (experienceInfo == null)
            {
                return NotFound();
            }
            return Ok(experienceInfo);
        }

        [HttpPost]
        public async Task<ActionResult> CreateExperienceInfo([FromBody] CreateExperienceInformationDto createExperienceInformationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _experienceInformationService.AddExperienceInfoAsync(createExperienceInformationDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateExperienceInfo(int id, [FromBody] UpdateExperienceInformationDto updateExperienceInformationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            updateExperienceInformationDto.Id = id;

            await _experienceInformationService.UpdateExperienceInfoAsync(updateExperienceInformationDto);
            return Ok();
        }

        // DELETE: api/ExperienceInformation/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExperienceInfo(int id)
        {
            await _experienceInformationService.DeleteExperienceInfoAsync(id);
            return Ok();
        }
    }
}
