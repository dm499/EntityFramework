using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public partial class StatusTypes
    {
        public StatusTypes()
        {
            PettyCashRequests = new HashSet<PettyCashRequests>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength (50)]
        public string Name { get; set; }

        [Required]
        [StringLength (1500)]
        public string Description { get; set; }

        public virtual ICollection<PettyCashRequests> PettyCashRequests { get; set; }
    }
}
