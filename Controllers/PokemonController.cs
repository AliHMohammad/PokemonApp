
//SKAL VÆRE AspNetCore.Mvc!!!
using Microsoft.AspNetCore.Mvc;
using PokemonApp.Entities;
using PokemonApp.Interfaces;

namespace PokemonApp.Controllers
{
    [Route("api/pokemons")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            this._pokemonService = pokemonService;
        }


        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<Pokemon>>> GetPokemons()
        {
            var pokemons = await _pokemonService.GetPokemons();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(pokemons);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Pokemon>> GetSinglePokemon(int id)
        {
            if (id < 1) return BadRequest("Id must be greater than 0");

            try
            {
                return Ok(await _pokemonService.GetSinglePokemon(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
