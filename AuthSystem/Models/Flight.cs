using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Airline { get; set; }
        [Required]
        public DateTime Time { get; set; }
    }
}
