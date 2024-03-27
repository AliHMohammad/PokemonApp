using PokemonApp.Entities;
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
            return await _pokemonRepository.GetSinglePokemon(id);
        }

    }
}
