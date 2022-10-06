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

        [Column(TypeName = "nvarchar(12)")]
        [DisplayName("Account number")]
        [Required(ErrorMessage ="This field is required.")]
        [MaxLength(12, ErrorMessage ="Maximum 12 characters only.")]
        public string AccountNumber { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Beneficiary name")]
        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters only.")]
        public string BeneficiaryName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Bank number")]
        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters only.")]
        public string BankName { get; set; }

        [Column(TypeName = "nvarchar(11)")]
        [DisplayName("SWIFT code")]
        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(11, ErrorMessage = "Maximum 11 characters only.")]
        public string SWIFTCode { get; set; }


        [Required]
        public int Amount { get; set; }

        [DisplayFormat(DataFormatString ="{0:dd-MMM-yy}")]
        public DateTime Date { get; set; }
    }
}
