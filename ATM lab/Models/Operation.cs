using System;
using System.ComponentModel.DataAnnotations;


namespace ATM_lab.Models
{
    public class Operation
    {
        public int Id { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string Type { get; set; }

        public decimal Amount { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }
    }
}
