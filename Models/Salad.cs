using System;
using System.ComponentModel.DataAnnotations;

namespace burgershack.Models
{
    public class Salad
    {

        public int Id { get; set; }

        [Required]
        [MinLength(6)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]

        public decimal Price { get; set; }

        public Salad() { }
        public Salad(string name, string description, decimal price = 5.00m)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }
}