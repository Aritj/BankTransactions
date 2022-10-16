using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankTransactions.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [ForeignKey("BankAccountForeignKey")]
        [DisplayName("Account number (sender)")]
        [Required(ErrorMessage ="This field is required.")]
        public int FromAccountNumber { get; set; }

        [ForeignKey("BankAccountForeignKey")]
        [DisplayName("Account number (receiver)")]
        [Required(ErrorMessage = "This field is required.")]
        public int ToAccountNumber { get; set; }

        [DisplayName("Transaction amount")]
        [Required(ErrorMessage = "This field is required.")]
        public Double Amount { get; set; }

        [DisplayFormat(DataFormatString ="{0:dd-MMM-yy HH:mm:ss}")]
        [Required(ErrorMessage = "This field is required.")]
        public DateTime Date { get; set; }
    }
}