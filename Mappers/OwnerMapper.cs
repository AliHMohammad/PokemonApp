using PokemonApp.DTOs;
using PokemonApp.Entities;

namespace PokemonApp.Mappers
{
    public static class OwnerMapper
    {

        public static ResponseOwnerDTO ToDTO(this Owner owner)
        {
            return new ResponseOwnerDTO(
                owner.Id,
                owner.FirstName,
                owner.LastName
                );
        }

        public static ResponseOwnerDetailedDTO ToDetailedDTO(this Owner owner)
        {
            return new ResponseOwnerDetailedDTO(
                owner.Id,
                owner.FirstName,
                owner.LastName,
                owner.Pokemons.Select(p => p.ToDTO()).ToList()
            );
        }


    }
}
