using Domain.Models;
using Infrastructur.Contrat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeroCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerController : ControllerBase
    {
        private readonly IGenerique<Powers> _power;

        public PowerController(IGenerique<Powers> power)
        {
            _power = power;
        }
        [HttpGet("id")]
        public ActionResult GetPower(int id )
        {
            Powers powerReturned = _power.getOne(id);
            if (powerReturned == null)
            {
                return NotFound();
            }
            return Ok(powerReturned);
        }
    }
}
