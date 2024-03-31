using Microsoft.AspNetCore.Mvc;
using PokemonApp.DTOs;
using PokemonApp.Interfaces;


namespace PokemonApp.Controllers
{
    [Route("api/owners")]
    [ApiController]
    public class OwnerController : ControllerBase
    {

        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseOwnerDTO>> GetOwners()
        {
            return Ok(await _ownerService.GetOwners());
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<ResponseOwnerDetailedDTO>> GetSingleOwner(int id)
        {
            return Ok(await _ownerService.GetSingleOwner(id));
        }


        //[HttpPost]
        //public void Post([FromBody] Owner owner)
        //{
        //}


        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}


        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
