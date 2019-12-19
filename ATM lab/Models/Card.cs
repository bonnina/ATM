using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance{ get; set; }

        [Required]
        public int FailedLogins { get; set; }

        [Required]
        public bool Blocked { get; set; }

        public virtual ICollection<Operation> Operations { get; set; }
    }
}
