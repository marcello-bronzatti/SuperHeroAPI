using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Interfaces.Services;
using SuperHeroAPI.Models.SuperHeroModel;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _service;

        public SuperHeroController(ISuperHeroService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _service.Get());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetById(int id)
        {
            try
            {
                var hero = await _service.GetById(id);
                return Ok(hero);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            await _service.AddHero(hero);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero request)
        {
            try
            {
                await _service.UpdateHero(request);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>> Delete(int id)
        {
            try
            {
                await _service.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
