using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public partial class GenderTypes
    {
        public GenderTypes()
        {
            Employees = new HashSet<Employees>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
