using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankTransactions.Models
{
    public class BankAccount
    {
        [Key]
        [DisplayName("Bank account number")]
        public int BankAccountId { get; set; }

        [ForeignKey("BankForeignKey")]
        [Required]
        [DisplayName("Bank number")]
        public int BankId { get; set; }

        [ForeignKey("CustomerForeignKey")]
        [Required]
        [DisplayName("Customer number")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Account amount")]
        public Double Amount { get; set; }
    }
}
