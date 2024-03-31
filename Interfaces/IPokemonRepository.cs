using PokemonApp.Entities;

namespace PokemonApp.Interfaces
{
    public interface IPokemonRepository
    {
        Task<List<Pokemon>> GetPokemons();
        Task<Pokemon?> GetSinglePokemon(int id);
        Task DeletePokemonByEntity(Pokemon pokemon);
        Task<Pokemon> CreatePokemon(Pokemon pokemon);
    }
}
