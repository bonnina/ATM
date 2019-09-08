using System.ComponentModel.DataAnnotations;


namespace ATM_lab.Models
{
    public class Card
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"\d{16}", ErrorMessage = "Card number should be 16 digits")]
        public string CardNumber { get; set; }

        [Required]
        [StringLength(4)]
        public string PIN { get; set; }

        [Required]
        public int FailedLogins { get; set; }

        [Required]
        public bool Blocked { get; set; }
    }
}
