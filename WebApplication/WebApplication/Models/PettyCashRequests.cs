using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public partial class PettyCashRequests
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength (1500)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int? EmployeeId { get; set; }

        public int? CurrencyTypeId { get; set; }

        public int? StatusTypeId { get; set; }

        [Display(Name = "Currency")]
        public virtual CurrencyTypes CurrencyType { get; set; }

        public virtual Employees Employee { get; set; }

        [Display(Name = "Status")]
        public virtual StatusTypes StatusType { get; set; }
    }
}
