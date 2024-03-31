namespace PokemonApp.DTOs
{
    public record ResponseOwnerDetailedDTO(
        int Id,
        string Firstname,
        string Lastname,
        List<ResponsePokemonDTO> Pokemons
        );

}
