
using Horas.Entities;
using Horas.Services;
using Microsoft.AspNetCore.Mvc;

namespace Horas.Controllers
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
            var date = DateTime.Today.Day;
            var h = HourS.Get(id);
            return Ok(new { hour = h, date = date.ToString() });
        }


        [HttpPost("sum")]
        public IActionResult Sum([FromBody] SumRequest request)
        {
            if (request == null)
                return BadRequest("Request is null");
            var r = HourS.Sum(request);

            return Ok(new { result = r });
        }
        [HttpPut()]
        public IActionResult Put([FromBody] PutRequest request)
        {
            var h = HourS.Update(request);
            return Ok(new { hour = h });
        }
    }

}