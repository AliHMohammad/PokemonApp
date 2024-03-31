using Microsoft.EntityFrameworkCore;
using PokemonApp.Data;
using PokemonApp.Entities;
using PokemonApp.Interfaces;

namespace PokemonApp.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {

        private readonly DataContext _dataContext;

        public OwnerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<List<Owner>> GetOwners()
        {
            return await _dataContext.Owners
                .OrderBy(o => o.Id).ToListAsync();
        }

        public async Task<Owner?> GetSingleOwner(int id)
        {
            return await _dataContext.Owners
                .Include(o => o.Pokemons)
                .FirstOrDefaultAsync(o => o.Id == id);
        }


    }
}
