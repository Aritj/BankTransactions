using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BankTransactions.Models
{
    public class Bank
    {
        [Key]
        public int BankId { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Bank name")]
        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters only.")]
        public string BankName { get; set; }

        [DisplayName("Transaction rate")]
        [Required(ErrorMessage = "This field is required.")]
        public int TransactionRate { get; set; }
    }
}
