using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G05.Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuggyController : ControllerBase
    {
        [HttpGet("notfound")] // api/buggy/notfound
        public IActionResult GetNotFoundRequest()
        {
            return NotFound();
        }
       
        [HttpGet("servererror")] // api/buggy/servererror
        public IActionResult GetServerErrorRequest()
        {
            throw new Exception();
            return Ok();
        }
       
        [HttpGet("badrequest")] // api/buggy/badrequest
        public IActionResult GetBadRequest()
        {
            return BadRequest();
        }

        [HttpGet("badrequest/{id}")] // api/buggy/badrequest/ahmed
        public IActionResult GetBadRequest(int id)
        {
            return BadRequest();
        }
        
        [HttpGet("unaurhorized")] // api/buggy/unaurhorized
        public IActionResult GetUnauthorizedReques()
        {
            return Unauthorized();
        }





    }
}
