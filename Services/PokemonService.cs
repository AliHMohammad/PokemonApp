using PokemonApp.Data;
using PokemonApp.DTOs;
using PokemonApp.Entities;
using PokemonApp.ExceptionHandlers;
using PokemonApp.Interfaces;
using PokemonApp.Mappers;

namespace PokemonApp.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PokemonService(IPokemonRepository pokemonRepository, IOwnerRepository ownerRepository, IUnitOfWork unitOfWork)
        {
            _pokemonRepository = pokemonRepository;
            _ownerRepository = ownerRepository;
            // Bruges til transactions
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ResponsePokemonDTO>> GetPokemons()
        {
            var pokemons = await _pokemonRepository.GetPokemons();
            return pokemons.Select(pokemon => pokemon.ToDTO());
        }

        public async Task<ResponsePokemonDTO> GetSinglePokemon(int id)
        {
            //Da vores resultat kan være null, laver vi en null operator og smider en custom NotFoundException
            Pokemon pokemon = await _pokemonRepository.GetSinglePokemon(id)
                ?? throw new NotFoundException($"Pokemon with ID {id} not found");

            return pokemon.ToDTO();
        }

        public async Task<ResponsePokemonDTO> DeletePokemon(int id)
        {
            //Finder pokemon, der skal slettes
            Pokemon pokemondb = await _pokemonRepository.GetSinglePokemon(id)
                ?? throw new NotFoundException($"Pokemon with id {id} could not be found");

            //Vi sletter
            await _pokemonRepository.DeletePokemonByEntity(pokemondb);

            return pokemondb.ToDTO();
        }

        public async Task<ResponsePokemonDTO> CreatePokemon(RequestPokemonDTO requestPokemonDTO)
        {
            Pokemon createdPokemon = await _pokemonRepository.CreatePokemon(requestPokemonDTO.ToEntity())
                ?? throw new BadRequestException("Could not create new pokemon");

            return createdPokemon.ToDTO();
        }


        // Eksempel på en transaction.
        public async Task<ResponsePokemonDTO> UpdatePokemon(RequestPokemonDTO requestPokemonDTO, int id)
        {
            // Begynd en transaction.
            using var transaction = _unitOfWork.BeginTransaction();

            var pokemonDb = await _pokemonRepository.GetSinglePokemon(id)
                ?? throw new NotFoundException($"Pokemon with id {id} not found");

            pokemonDb.Name = requestPokemonDTO.Name;
            pokemonDb.BirthDate = requestPokemonDTO.BirthDate;

            // Ikke er i request body, så defaulter den til 0, i stedet for null i spring boot
            // Hvis ownerId er med i requestbody, så opdater den, ellers, skip.
            if (requestPokemonDTO.OwnerId != 0)
            {
                var ownerId = requestPokemonDTO.OwnerId;

                if (!await _ownerRepository.OwnerExists(ownerId))
                    throw new BadRequestException($"ownerId {ownerId} not found");

                pokemonDb.OwnerId = ownerId;
            }

            // Vi gemmer en ændring i db
            await _unitOfWork.SaveChangesAsync();

            // Hvis der var mere logik med en anden entitet, så udfør det her
            // Gem ovenstående ændring med await _unitOfWork.SaveChangesAsync();
            // I tilfælde af exception, så husk at kald transaction.Rollback(), inden du kaster den.

            ///if (blabla)
            ///{
            ///    transaction.Rollback();
            ///    throw new BadRequestException($"Blablabla");
            ///}


            // Vi afslutter med at commit vores transaction inden vi returnerer til controller
            transaction.Commit();
            return (await _pokemonRepository.GetSinglePokemon(id)).ToDTO();
        }

    }
}
