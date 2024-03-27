using PokemonApp.DTOs;
using PokemonApp.Entities;
using PokemonApp.ExceptionHandlers;
using PokemonApp.Interfaces;
using PokemonApp.Mappers;

namespace PokemonApp.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonService(IPokemonRepository pokemonRepository)
        {
            this._pokemonRepository = pokemonRepository;
        }

        public async Task<IEnumerable<ResponsePokemonDTO>> GetPokemons()
        {
            var pokemons = await _pokemonRepository.GetPokemons();
            return pokemons.Select(pokemon => pokemon.ToDTO());
        }

        public async Task<Pokemon> GetSinglePokemon(int id)
        {
            Pokemon? pokemon = await _pokemonRepository.GetSinglePokemon(id);

            if (pokemon is null) throw new NotFoundException($"Pokemon with ID {id} not found");

            return pokemon;
        }

    }
}
