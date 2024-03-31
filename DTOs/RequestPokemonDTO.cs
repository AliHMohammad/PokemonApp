namespace PokemonApp.DTOs
{
    public record RequestPokemonDTO(
            string Name,
            DateTime BirthDate,
            int OwnerId
        );


}
