using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ATM_lab.Models
{
    public class Card
    {
        public int Id { get; set; }

        [Required]
        [CreditCard]
        public string CardNumber { get; set; }

        [Required]
        [StringLength(4)]
        public string PIN { get; set; }

        [Required]
        public int FailedLogins { get; set; }

        [Required]
        public bool Blocked { get; set; }

        public virtual ICollection<Operation> Operations { get; set; }
    }
}
