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
        [Column(TypeName = "nvarchar(12)")]
        [DisplayName("Account number")]
        [Required(ErrorMessage ="This field is required.")]
        [MaxLength(12, ErrorMessage ="Maximum 12 characters only.")]
        public string FromAccountNumber { get; set; }

        [ForeignKey("BankAccountForeignKey")]
        [Column(TypeName = "nvarchar(12)")]
        [DisplayName("Account number")]
        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(12, ErrorMessage = "Maximum 12 characters only.")]
        public string ToAccountNumber { get; set; }

        [Required]
        public int Amount { get; set; }

        [DisplayFormat(DataFormatString ="{0:dd-MMM-yy}")]
        public DateTime Date { get; set; }
    }
}
