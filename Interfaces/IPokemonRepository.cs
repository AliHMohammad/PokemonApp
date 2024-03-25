using PokemonApp.Entities;

namespace PokemonApp.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
    }
}
