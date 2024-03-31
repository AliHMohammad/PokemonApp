using PokemonApp.DTOs;
using PokemonApp.ExceptionHandlers;
using PokemonApp.Interfaces;
using PokemonApp.Mappers;

namespace PokemonApp.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }


        public async Task<IEnumerable<ResponseOwnerDTO>> GetOwners()
        {
            var owners = await _ownerRepository.GetOwners();
            return owners.Select(o => o.ToDTO());
        }

        public async Task<ResponseOwnerDetailedDTO> GetSingleOwner(int id)
        {
            var ownerDb = await _ownerRepository.GetSingleOwner(id)
                ?? throw new NotFoundException($"Owner with id {id} not found");

            return ownerDb.ToDetailedDTO();
        }

    }
}
