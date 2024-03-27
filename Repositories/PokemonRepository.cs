using Microsoft.EntityFrameworkCore;
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


        public async Task<List<Pokemon>> GetPokemons()
        {
            return await _dataContext.Pokemons.OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<Pokemon> GetSinglePokemon(int id)
        {
            var result = await _dataContext.Pokemons.FindAsync(id);

            if (result == null)
            {
                throw new Exception($"Pokemon with ID {id} not found");
            }

            return result;
        }


    }
}
