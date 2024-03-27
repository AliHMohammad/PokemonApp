using PokemonApp.Entities;

namespace PokemonApp.Interfaces
{
    public interface IPokemonService
    {

        Task<IEnumerable<Pokemon>> GetPokemons();
        Task<Pokemon> GetSinglePokemon(int id);
    }
}
