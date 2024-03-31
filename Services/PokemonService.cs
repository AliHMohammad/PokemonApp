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

        public PokemonService(IPokemonRepository pokemonRepository)
        {
            this._pokemonRepository = pokemonRepository;
        }

        public async Task<IEnumerable<ResponsePokemonDTO>> GetPokemons()
        {
            var pokemons = await _pokemonRepository.GetPokemons();
            return pokemons.Select(pokemon => pokemon.ToDTO());
        }

        public async Task<Pokemon> GetSinglePokemon(int id)
        {
            //Da vores resultat kan være null, laver vi en null operator og smider en custom NotFoundException
            Pokemon pokemon = await _pokemonRepository.GetSinglePokemon(id)
                ?? throw new NotFoundException($"Pokemon with ID {id} not found");

            return pokemon;
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

    }
}
