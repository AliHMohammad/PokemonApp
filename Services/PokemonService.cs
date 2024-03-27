using PokemonApp.Entities;
using PokemonApp.ExceptionHandlers;
using PokemonApp.Interfaces;

namespace PokemonApp.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonService(IPokemonRepository pokemonRepository)
        {
            this._pokemonRepository = pokemonRepository;
        }

        public async Task<IEnumerable<Pokemon>> GetPokemons()
        {
            return await _pokemonRepository.GetPokemons();
        }

        public async Task<Pokemon> GetSinglePokemon(int id)
        {
            Pokemon? pokemon = await _pokemonRepository.GetSinglePokemon(id);

            if (pokemon is null) throw new NotFoundException($"Pokemon with ID {id} not found");

            return pokemon;
        }

    }
}
