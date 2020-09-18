using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public partial class GenderTypes
    {
        public GenderTypes()
        {
            Employees = new HashSet<Employees>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength (50)]
        public string Name { get; set; }

        [Required]
        [StringLength (1500)]
        public string Description { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
