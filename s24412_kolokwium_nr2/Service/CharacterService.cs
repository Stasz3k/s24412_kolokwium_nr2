using s24412_kolokwium_nr2.DTOs;
using s24412_kolokwium_nr2.Repos;


namespace s24412_kolokwium_nr2.Service
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<CharacterDto> GetCharacterByIdAsync(int characterId)
        {
            var character = await _characterRepository.GetCharacterByIdAsync(characterId);
            if (character == null)
            {
                return null;
            }

            var characterDto = new CharacterDto
            {
                FirstName = character.FirstName,
                LastName = character.LastName,
                CurrentWeight = character.CurrentWeight,
                MaxWeight = character.MaxWeight,
                BackpackItems = character.Backpacks.Select(b => new BackpackItemDto
                {
                    ItemName = b.Item.Name,
                    ItemWeight = b.Item.Weight,
                    Amount = b.Amount
                }).ToList(),
                Titles = character.CharacterTitles.Select(ct => new CharacterTitleDto
                {
                    Title = ct.Title.Name,
                    AcquiredAt = ct.AcquiredAt
                }).ToList()
            };

            return characterDto;
        }

        public async Task<bool> AddItemsToBackpackAsync(int characterId, IEnumerable<int> itemIds)
        {
            return await _characterRepository.AddItemsToBackpackAsync(characterId, itemIds);
        }
    }
}