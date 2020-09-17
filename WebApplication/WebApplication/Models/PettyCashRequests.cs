using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public partial class PettyCashRequests
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int? EmployeeId { get; set; }
        public int? CurrencyTypeId { get; set; }
        public int? StatusTypeId { get; set; }

        public virtual CurrencyTypes CurrencyType { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual StatusTypes StatusType { get; set; }
    }
}
