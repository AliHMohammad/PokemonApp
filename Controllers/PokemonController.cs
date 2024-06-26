﻿
//SKAL VÆRE AspNetCore.Mvc!!!
using Microsoft.AspNetCore.Mvc;
using PokemonApp.DTOs;
using PokemonApp.ExceptionHandlers;
using PokemonApp.Interfaces;

namespace PokemonApp.Controllers
{
    [Route("api/pokemons")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponsePokemonDTO>>> GetPokemons()
        {
            return Ok(await _pokemonService.GetPokemons());
        }

        //Undlad :int, hvis din parameter er en string
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ResponsePokemonDTO>> GetSinglePokemon(int id)
        {
            if (id < 1) throw new NotFoundException($"Pokemon with ID {id} not found");

            return Ok(await _pokemonService.GetSinglePokemon(id));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ResponsePokemonDTO>> DeletePokemon(int id)
        {
            if (id < 1) throw new NotFoundException($"Pokemon with ID {id} not found");

            var deletedPokemon = await _pokemonService.DeletePokemon(id);

            return Ok(deletedPokemon);
        }


        [HttpPost]
        public async Task<ActionResult<ResponsePokemonDTO>> CreatePokemon([FromBody] RequestPokemonDTO requestPokemonDTO)
        {
            var pokemonResponse = await _pokemonService.CreatePokemon(requestPokemonDTO);

            // Udvidet ActionResult. Modtager 3 parametre:
            // 1. Navnet på metoden hvor man tilgår denne nye resurse på,
            // 2. "location"-header sat til URI til den nyoprettet resurse 
            // 3. ResponseBody, i vores tilfælde DTO'en
            return CreatedAtAction(nameof(GetSinglePokemon), new { id = pokemonResponse.Id }, pokemonResponse);
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<ResponsePokemonDTO>> UpdatePokemon([FromBody] RequestPokemonDTO requestPokemonDTO, int id)
        {
            if (id < 1) throw new NotFoundException($"Pokemon with ID {id} not found");

            return Ok(await _pokemonService.UpdatePokemon(requestPokemonDTO, id));
        }


    }
}

