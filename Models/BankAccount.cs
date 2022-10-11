using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankTransactions.Models
{
    public class BankAccount
    {
        [Key]
        public int BankAccountId { get; set; }

        [ForeignKey("BankForeignKey")]
        [Required]
        public int BankId { get; set; }

        [ForeignKey("CustomerForeignKey")]
        [Required]
        public int CustomerId { get; set; }
    }
}
