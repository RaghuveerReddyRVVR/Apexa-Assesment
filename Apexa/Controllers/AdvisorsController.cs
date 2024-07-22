using Apexa.Models;
using Apexa.Services;
using Microsoft.AspNetCore.Mvc;

namespace Apexa.Controllers
{
    
        [ApiController]
        [Route("api/[controller]")]
        public class AdvisorsController : ControllerBase
        {
            private readonly IAdvisorService _service;

            public AdvisorsController(IAdvisorService service)
            {
                _service = service;
            }

            [HttpGet]
            public async Task<IEnumerable<Advisor>> GetAdvisors()
            {
                return await _service.GetAdvisors();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Advisor>> GetAdvisor(int id)
            {
                var advisor = await _service.GetAdvisor(id);
                if (advisor == null)
                {
                    return NotFound();
                }
                return advisor;
            }

            [HttpPost]
            public async Task<ActionResult<Advisor>> CreateAdvisor(Advisor advisor)
            {
                var createdAdvisor = await _service.CreateAdvisor(advisor);
                return CreatedAtAction(nameof(GetAdvisor), new { id = createdAdvisor.Id }, createdAdvisor);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateAdvisor(int id, Advisor advisor)
            {
                if (id != advisor.Id)
                {
                    return BadRequest();
                }

                await _service.UpdateAdvisor(advisor);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteAdvisor(int id)
            {
                await _service.DeleteAdvisor(id);
                return NoContent();
            }
        }
    
}
