using AutoMapper;
using Domain.Models;
using HeroCRUD.ModelDTO;
using Infrastructure.contrat;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeroCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerController : ControllerBase
    {
        private readonly IGenerique<Powers> _power;
        private readonly IMapper _mapper;

        public PowerController(IGenerique<Powers> power, IMapper mapper)
        {
            _power = power;
            _mapper = mapper;
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
        [HttpGet]
        public ActionResult<IReadOnlyList<Powers>> GetAll()
        {
            try
            {
                return Ok(_power.GetAll());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult AddHero(PowerDTO power)
        {
            try
            {
                Powers powerToAdd = _mapper.Map<Powers>(power);
                _power.addOne(powerToAdd);
                return Ok("new power added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        public ActionResult UpdateHero(PowerDTO powerReceived)
        {
            try
            {
                Powers powerToUpdate = _mapper.Map<Powers>(powerReceived);
                _power.UpdateOne(powerToUpdate);
                return Ok(" power updated");
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
                _power.RemoveOne(id);
                return Ok("Power removed");
            }
            catch
            {
                return BadRequest("power not removed");
            }
        }
    }
}
