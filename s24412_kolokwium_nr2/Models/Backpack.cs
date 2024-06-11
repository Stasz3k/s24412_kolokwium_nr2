using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace s24412_kolokwium_nr2.Models
{


    public class Backpack
    {
        [Key, Column(Order = 0)]
        public int CharacterId { get; set; }
        [Key, Column(Order = 1)]
        public int ItemId { get; set; }
        public int Amount { get; set; }

        [ForeignKey("CharacterId")]
        public Character Character { get; set; }
        [ForeignKey("ItemId")]
        public Item Item { get; set; }
    }

}
