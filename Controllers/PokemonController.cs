
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
        public async Task<ActionResult<IEnumerable<ResponsePokemonDTO>>> GetPokemons()
        {
            return Ok(await _pokemonService.GetPokemons());
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pokemon>> GetSinglePokemon(int id)
        {
            if (id < 1) throw new BadRequestException($"Pokemon with ID {id} not found");

            return Ok(await _pokemonService.GetSinglePokemon(id));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ResponsePokemonDTO>> DeletePokemon(int id)
        {
            if (id < 1) throw new BadRequestException($"Pokemon with ID {id} not found");

            var pokemon = await _pokemonService.DeletePokemon(id);

            return Ok(pokemon);
        }


        [HttpPost]
        public async Task<ActionResult<ResponsePokemonDTO>> CreatePokemon(RequestPokemonDTO requestPokemonDTO)
        {
            var pokemonResponse = await _pokemonService.CreatePokemon(requestPokemonDTO);

            // Udvidet ActionResult. Modtager 3 parametre:
            // 1. Navnet på metoden hvor man tilgår denne nye resurse på,
            // 2. "location"-header sat til URI til den nyoprettet resurse 
            // 3. ResponseBody, i vores tilfælde DTO'en
            return CreatedAtAction(nameof(GetSinglePokemon), new { id = pokemonResponse.Id }, pokemonResponse);
        }
    }
}

