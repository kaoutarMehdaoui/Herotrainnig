using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HeroCRUD.ModelDTO;
using AutoMapper;
using Infrastructure.Contrat;

namespace HeroCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HerosController : ControllerBase
    {
        private readonly IGenerique<Heros> _Hero;
        private readonly IMapper _Mapper;
        
        public HerosController(IGenerique<Heros> hero, IMapper mapperConfig)
        {
            _Hero = hero;
            _Mapper = mapperConfig;
            
        }
        [HttpGet("id")]
        public ActionResult<Heros> GetHero(int id )
        {
            try
            {
                Heros HeroReturned = _Hero.getOne(id);
                if (HeroReturned == null)
                {
                    return NotFound();
                }
                return HeroReturned;
            }catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }
        [HttpGet]
        [Route("/Join")]
        public ActionResult<string> getHeroesIncludingPowers()
        {
            try
            {
                return _Hero.GetAll(src => src.Include(i => i.HeroPowers));

            }catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
           
            
           
        }
        [HttpGet]
        public ActionResult<IReadOnlyList<Heros>> GetAll() 
        {
            try
            {
                return Ok(_Hero.GetAll());
            }catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult AddHero(HeroDTO hero)
        {
            try
            {
                Heros heroToAdd = _Mapper.Map<Heros>(hero);
                 _Hero.addOne(heroToAdd);
                return Ok("new hero added");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpPut]
        public ActionResult UpdateHero(HeroDTO hero)
        {
            try
            {
                Heros heroToAdd = _Mapper.Map<Heros>(hero);
                _Hero.UpdateOne(heroToAdd);
                return Ok(" hero updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        public ActionResult DeleteHero(int id)
        {
            try
            {
                _Hero.RemoveOne(id);
                return Ok("Hero removed");
            }
            catch
            {
                return BadRequest("hero not removed");
            }
        }
    }
}
