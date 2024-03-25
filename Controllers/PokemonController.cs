
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
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonController(IPokemonRepository pokemonRepository)
        {
            this._pokemonRepository = pokemonRepository;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Pokemon>))]
        public IActionResult getPokemons()
        {
            var pokemons = _pokemonRepository.GetPokemons();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(pokemons);
        }
    }
}
