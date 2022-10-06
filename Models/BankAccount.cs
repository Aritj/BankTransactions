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
        public Bank Bank { get; set; }

        [ForeignKey("CustomerForeignKey")]
        [Required]
        public Customer Customer { get; set; }
    }
}
