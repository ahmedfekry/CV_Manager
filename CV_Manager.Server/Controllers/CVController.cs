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
    public class CVController : ControllerBase
    {
        private readonly CVService _cvService;

        public CVController(CVService cvService)
        {
            _cvService = cvService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CVDto>>> GetAllCVs()
        {
            var cvs = await _cvService.GetAllCVsAsync();
            return Ok(cvs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CVDto>> GetCVById(int id)
        {
            var cv = await _cvService.GetByIdAsync(id);
            if (cv == null)
            {
                return NotFound();
            }
            return Ok(cv);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCV([FromBody] CreateCVDto createCVDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _cvService.AddAsync(createCVDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCV(int id, [FromBody] UpdateCVDto updateCVDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            updateCVDto.Id = id;

            await _cvService.UpdateCVAsync(updateCVDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCV(int id)
        {
            await _cvService.DeleteCVAsync(id);
            return Ok();
        }
    }
}
