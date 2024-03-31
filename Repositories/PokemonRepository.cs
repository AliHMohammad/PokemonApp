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

        public async Task<Pokemon?> GetSinglePokemon(int id)
        {
            return await _dataContext.Pokemons
                .Include(p => p.Owner)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task DeletePokemonByEntity(Pokemon pokemon)
        {
            _dataContext.Pokemons.Remove(pokemon);
            //Vi persister sletningen ved at gemme
            await _dataContext.SaveChangesAsync();
        }


        public async Task<Pokemon?> CreatePokemon(Pokemon pokemon)
        {
            //Vi opretter og gemmer
            var createdPokemon = await _dataContext.Pokemons.AddAsync(pokemon);
            await _dataContext.SaveChangesAsync();

            // Vi kalder getSingle, så vi får vores .Include p.Owner på vores resultat.
            return await GetSinglePokemon(createdPokemon.Entity.Id);

            // Returnerer vi blot createdPokemon.Entity, får vi p.Owner som null.
        }


    }
}
