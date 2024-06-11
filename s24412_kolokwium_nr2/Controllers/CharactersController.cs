using Microsoft.AspNetCore.Mvc;
using s24412_kolokwium_nr2.Service;
using s24412_kolokwium_nr2.DTOs;

namespace s24412_kolokwium_nr2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }
        
        [HttpGet("{characterId}")]
        public async Task<ActionResult<CharacterDto>> GetCharacter(int characterId)
        {
            var character = await _characterService.GetCharacterByIdAsync(characterId);
            if (character == null)
            {
                return NotFound();
            }

            return Ok(character);
        }
        
        [HttpPost("{characterId}/backpacks")]
        public async Task<ActionResult> AddItemsToBackpack(int characterId, [FromBody] IEnumerable<int> itemIds)
        {
            var success = await _characterService.AddItemsToBackpackAsync(characterId, itemIds);
            if (!success)
            {
                return BadRequest("One or more items do not exist or character cannot carry that much weight.");
            }

            return Ok();
        }
    }
}