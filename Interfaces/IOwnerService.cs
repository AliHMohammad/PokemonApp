using PokemonApp.DTOs;

namespace PokemonApp.Interfaces
{
    public interface IOwnerService
    {

        Task<IEnumerable<ResponseOwnerDTO>> GetOwners();
        Task<ResponseOwnerDetailedDTO> GetSingleOwner(int id);

    }
}
