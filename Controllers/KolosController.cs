using kolos2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KolosController : ControllerBase
    {
        private readonly IKolosService _service;
        public KolosController(IKolosService service) 
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) 
        {
            if (!await _service.MusExists(id))
                return NotFound("No musician wa found");
            return Ok(await _service.GetMusician(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            if (!await _service.MusExists(id))
                return StatusCode(400, "No musician found");

            await _service.DeleteMusician(id);
            return Ok("Musician removed");
        }
    }
}
