using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArrearsActionAPI.V1.Boundary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArrearsActionAPI.Controllers
{
    [Route("api/v1/ArrearsActions")]
    [ApiController]
    public class ArrearsActionsController : ControllerBase
    {
        [HttpGet]
        [Route("Hello/Name/{name}")]
        public IActionResult HelloSomeone([FromRoute] string name)
        {
            return Ok($"It's working?! Uhm... Hello, {name}!");
        }
    }
}