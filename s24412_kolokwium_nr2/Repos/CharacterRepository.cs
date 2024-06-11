using Microsoft.EntityFrameworkCore;
using s24412_kolokwium_nr2.Models;
using s24412_kolokwium_nr2.Data;


namespace s24412_kolokwium_nr2.Repos
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly s24412DbContext _context;

        public CharacterRepository(s24412DbContext context)
        {
            _context = context;
        }

        public async Task<Character> GetCharacterByIdAsync(int characterId)
        {
            return await _context.Characters
                .Include(c => c.Backpacks)
                    .ThenInclude(b => b.Item)
                .Include(c => c.CharacterTitles)
                    .ThenInclude(ct => ct.Title)
                .FirstOrDefaultAsync(c => c.Id == characterId);
        }

        public async Task<bool> AddItemsToBackpackAsync(int characterId, IEnumerable<int> itemIds)
        {
            var character = await _context.Characters.Include(c => c.Backpacks).FirstOrDefaultAsync(c => c.Id == characterId);
            if (character == null)
            {
                return false;
            }

            var items = await _context.Items.Where(i => itemIds.Contains(i.Id)).ToListAsync();
            if (items.Count != itemIds.Count())
            {
                return false;
            }

            var totalWeight = items.Sum(i => i.Weight);
            if (character.CurrentWeight + totalWeight > character.MaxWeight)
            {
                return false;
            }

            foreach (var item in items)
            {
                var backpack = character.Backpacks.FirstOrDefault(b => b.ItemId == item.Id);
                if (backpack != null)
                {
                    backpack.Amount++;
                }
                else
                {
                    character.Backpacks.Add(new Backpack
                    {
                        CharacterId = characterId,
                        ItemId = item.Id,
                        Amount = 1
                    });
                }
                character.CurrentWeight += item.Weight;
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
