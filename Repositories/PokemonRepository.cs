using PokemonApp.Data;
using PokemonApp.Entities;
using PokemonApp.Interfaces;

namespace PokemonApp.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _dataContext;

        public PokemonRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }


        public ICollection<Pokemon> GetPokemons()
        {
            return _dataContext.Pokemons.OrderBy(p => p.Id).ToList();
        }
    }
}
