using System.ComponentModel.DataAnnotations;

namespace ATM_lab.Models
{
    public class PIN
    {
        [Required]
        [StringLength(4)]
        public string Code { get; set; }

        [Required]
        public int AttemptNum { get; set; }
    }
}
