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
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            return Ok();
        }
    }
}
