using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BankTransactions.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Customer name")]
        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters only.")]
        public string CustomerName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yy}")]
        [Required]
        public DateTime Birthday { get; set; }
    }
}
