using s24412_kolokwium_nr2.DTOs;


namespace s24412_kolokwium_nr2.Service
{
    public interface ICharacterService
    {
        Task<CharacterDto> GetCharacterByIdAsync(int characterId);
        Task<bool> AddItemsToBackpackAsync(int characterId, IEnumerable<int> itemIds);
    }
}