using s24412_kolokwium_nr2.Models;

namespace s24412_kolokwium_nr2.Repos
{
    public interface ICharacterRepository
    {
        Task<Character> GetCharacterByIdAsync(int characterId);
        Task<bool> AddItemsToBackpackAsync(int characterId, IEnumerable<int> itemIds);
    }
}