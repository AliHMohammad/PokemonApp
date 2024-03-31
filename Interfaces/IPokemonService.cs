using PokemonApp.DTOs;

namespace PokemonApp.Interfaces
{
    public interface IPokemonService
    {
        Task<ResponsePokemonDTO> CreatePokemon(RequestPokemonDTO requestPokemonDTO);
        Task<ResponsePokemonDTO> DeletePokemon(int id);
        Task<IEnumerable<ResponsePokemonDTO>> GetPokemons();
        Task<ResponsePokemonDTO> GetSinglePokemon(int id);
        Task<ResponsePokemonDTO> UpdatePokemon(RequestPokemonDTO requestPokemonDTO, int id);
    }
}


