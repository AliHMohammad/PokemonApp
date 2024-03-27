
//SKAL VÆRE AspNetCore.Mvc!!!
using Microsoft.AspNetCore.Mvc;
using PokemonApp.DTOs;
using PokemonApp.Entities;
using PokemonApp.ExceptionHandlers;
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
        public async Task<ActionResult<IEnumerable<ResponsePokemonDTO>>> GetPokemons()
        {
            var pokemons = await _pokemonService.GetPokemons();
            return Ok(pokemons);
        }


        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Pokemon>> GetSinglePokemon(int id)
        {
            if (id < 1) throw new BadRequestException($"Pokemon with ID {id} not found");

            return Ok(await _pokemonService.GetSinglePokemon(id));
        }
    }
}
