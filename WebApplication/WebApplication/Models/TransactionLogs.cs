using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public partial class TransactionLogs
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Credit { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }
    }
}
