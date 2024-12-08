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
    public class PersonalInformationController : ControllerBase
    {
        private readonly PersonalInformationService _personalInformationService;

        public PersonalInformationController(PersonalInformationService personalInformationService)
        {
            _personalInformationService = personalInformationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalInformationDto>>> GetAllPersonalInfo()
        {
            var personalInfo = await _personalInformationService.GetAllPersonalInfoAsync();
            return Ok(personalInfo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalInformationDto>> GetPersonalInfoById(int id)
        {
            var personalInfo = await _personalInformationService.GetPersonalInfoByIdAsync(id);
            if (personalInfo == null)
            {
                return NotFound();
            }
            return Ok(personalInfo);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePersonalInfo([FromBody] CreatePersonalInformationDto createPersonalInformationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _personalInformationService.AddPersonalInfoAsync(createPersonalInformationDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePersonalInfo(int id, [FromBody] UpdatePersonalInformationDto updatePersonalInformationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            updatePersonalInformationDto.Id = id;  

            await _personalInformationService.UpdatePersonalInfoAsync(updatePersonalInformationDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePersonalInfo(int id)
        {
            await _personalInformationService.DeletePersonalInfoAsync(id);
            return Ok();
        }
    }
}
