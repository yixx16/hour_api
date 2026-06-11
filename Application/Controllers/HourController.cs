
using Horas.Core.Entities;
using Horas.Services;
using Horas.Request;
using Microsoft.AspNetCore.Mvc;

namespace Horas.Application.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HourController(HourService hourService) : ControllerBase
    {
        //mirar la inyeccion de dependencias luego
        private readonly HourService HourS = hourService;
        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            var h = HourS.Get(id);
            return Ok(new { hour = h});
        }


        [HttpPost("sum")]
        public IActionResult Sum([FromBody] SumRequest request)
        {
            if (request == null)
                return BadRequest("Request is null");
            var hour = HourS.Sum(request);
            return Created($"/api/hour/{hour.Id}", hour);
        }
        [HttpPut()]
        public IActionResult Put([FromBody] PutRequest request)
        {
            var h = HourS.Update(request);
            return Ok(new { hour = h });
        }
    }

}