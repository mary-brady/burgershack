using System.ComponentModel.DataAnnotations;

namespace burgershack.Models
{
    public class Smoothie
    {
        [Required]
        [MinLength(6)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Id { get; set; }


        public Smoothie()
        {

        }
        public Smoothie(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }
}