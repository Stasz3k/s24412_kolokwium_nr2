using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace s24412_kolokwium_nr2.Models
{

    public class CharacterTitle
    {
        [Key, Column(Order = 0)]
        public int CharacterId { get; set; }
        [Key, Column(Order = 1)]
        public int TitleId { get; set; }
        public DateTime AcquiredAt { get; set; }

        [ForeignKey("CharacterId")]
        public Character Character { get; set; }
        [ForeignKey("TitleId")]
        public Title Title { get; set; }
    }

}
