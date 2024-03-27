using PokemonApp.DTOs;
using PokemonApp.Entities;

namespace PokemonApp.Mappers
{
    public static class PokemonMapper
    {

        public static ResponsePokemonDTO ToDTO(this Pokemon pokemon)
        {
            return new ResponsePokemonDTO(
                pokemon.Id,
                pokemon.Name
            );
        }

    }
}
