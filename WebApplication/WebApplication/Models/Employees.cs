using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public partial class Employees
    {
        public Employees()
        {
            PettyCashRequests = new HashSet<PettyCashRequests>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength (50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength (50)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength (50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength (150)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength (20)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        public int? GenderTypeId { get; set; }

        [Display(Name = "Gender")]
        public virtual GenderTypes GenderType { get; set; }

        public virtual ICollection<PettyCashRequests> PettyCashRequests { get; set; }
    }
}
