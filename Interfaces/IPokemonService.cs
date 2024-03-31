using PokemonApp.DTOs;
using PokemonApp.Entities;

namespace PokemonApp.Interfaces
{
    public interface IPokemonService
    {
        Task<ResponsePokemonDTO> CreatePokemon(RequestPokemonDTO requestPokemonDTO);
        Task<ResponsePokemonDTO> DeletePokemon(int id);
        Task<IEnumerable<ResponsePokemonDTO>> GetPokemons();
        Task<Pokemon> GetSinglePokemon(int id);
        Task<ResponsePokemonDTO> UpdatePokemon(RequestPokemonDTO requestPokemonDTO, int id);
    }
}
