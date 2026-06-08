using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;

namespace Horas
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class HourController : ControllerBase
    {
        //mirar la inyeccion de dependencias luego
        HourService hservice = new();
        
        
        [HttpPost("sum")]
         public IActionResult Sum([FromBody] HourRequest request){
            if (request == null)
                return BadRequest("Request is null");
            var result = hservice.Sum(request);
            
            return Ok(new {result = result.ToString()});
        }
    }

}