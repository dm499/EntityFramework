using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public partial class CurrencyTypes
    {
        public CurrencyTypes()
        {
            PettyCashRequests = new HashSet<PettyCashRequests>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PettyCashRequests> PettyCashRequests { get; set; }
    }
}
