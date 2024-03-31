using PokemonApp.Entities;

namespace PokemonApp.Interfaces
{
    public interface IOwnerRepository
    {
        Task<List<Owner>> GetOwners();
        Task<Owner?> GetSingleOwner(int id);
        Task<bool> OwnerExists(int id);
    }
}

