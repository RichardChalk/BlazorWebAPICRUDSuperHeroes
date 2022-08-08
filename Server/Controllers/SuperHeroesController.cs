using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace SuperHeroes.Server.Controllers
{
    [Route("api/[controller]")] // eg. https://localhost:7067/api/SuperHeroes
    [ApiController]
    public class SuperHeroesController : ControllerBase
    {
        public static List<Comic> Comics = new List<Comic>
        {
            new Comic {Id = 1, Name = "Marvel"},
            new Comic {Id = 2, Name = "DC"}
        };

        public static List<SuperHero> Heroes = new List<SuperHero>
        {
            new SuperHero {
                Id = 1,
                FirstName = "Peter",
                LastName = "Parker",
                HeroName = "SpiderMan",
                Comic = Comics[0]
            },
            new SuperHero {
                Id = 2,
                FirstName = "Bruce",
                LastName = "Wayne",
                HeroName = "BatMan",
                Comic = Comics[1]
            },
        };

        //  READ -  READ -  READ -  READ -  READ -  READ -  READ -  READ -  READ
        //  READ -  READ -  READ -  READ -  READ -  READ -  READ -  READ -  READ
        //  READ -  READ -  READ -  READ -  READ -  READ -  READ -  READ -  READ
        //  READ -  READ -  READ -  READ -  READ -  READ -  READ -  READ -  READ
        
        [HttpGet]
        // Returning an ActionResult means we can also return a status code 
        // as well as our heroes
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            return Ok(Heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleSuperHero(int id)
        {
            var hero = Heroes.FirstOrDefault(h => h.Id == id);
            if (hero == null)
            {
                return BadRequest("No hero found with that Id!");
            }
            
            return Ok(hero);
        }


    }
}
