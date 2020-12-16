using System;
using System.ComponentModel.DataAnnotations;

namespace Primeiro.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(17)]
        public string Chassi { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public DateTime YearManufacture { get; set; }

        [Required]
        public DateTime YearModel { get; set; }
    }
}