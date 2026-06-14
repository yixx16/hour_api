
using Horas.Domain.Entities;
using Horas.Domain.Services;
using Horas.Api.Request;
using Microsoft.AspNetCore.Mvc;

namespace Horas.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HourController(HourService hourService) : ControllerBase
    {
        //mirar la inyeccion de dependencias luego
        private readonly HourService HourS = hourService;

        [HttpGet]
        public ActionResult<IEnumerable<Hour>> GetAll()
        {
            return Ok(HourS.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult<Hour> Get([FromRoute] int id)
        {
            var h = HourS.Get(id);
            return h;
        }


        [HttpPost("sum")]
        public ActionResult<Hour> Sum([FromBody] SumRequest request)
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

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            HourS.Del(id);
            return NoContent();
        }
    }

}