using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public partial class TransactionLogs
    {
        public int Id { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }
    }
}
