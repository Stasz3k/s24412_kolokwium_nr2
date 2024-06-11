using System.Collections.Generic;

namespace s24412_kolokwium_nr2.DTOs
{
    public class CharacterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CurrentWeight { get; set; }
        public int MaxWeight { get; set; }
        public List<BackpackItemDto> BackpackItems { get; set; }
        public List<CharacterTitleDto> Titles { get; set; }
    }
}