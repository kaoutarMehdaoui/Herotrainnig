using Domain.Models;
using Infrastructur.Contrat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeroCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HerosController : ControllerBase
    {
        private readonly IGenerique<Heros> _Hero;
        public HerosController(IGenerique<Heros> hero)
        {
            _Hero = hero;
        }
        [HttpGet("id")]
        public ActionResult<Heros> GetHero(int id )
        {
            Heros HeroReturned=_Hero.getOne(id);
            if(HeroReturned == null)
            {
                return NotFound();
            }
            return HeroReturned;
        }
    }
}
