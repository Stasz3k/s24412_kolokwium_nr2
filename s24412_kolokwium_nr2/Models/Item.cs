using System.ComponentModel.DataAnnotations;

namespace s24412_kolokwium_nr2.Models
{

    public class Item
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int Weight { get; set; }
    }

}
