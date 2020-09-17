using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeList.Models
{
    public class tblEmployee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Contact Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Your Skill")]
        public int SkillID { get; set; }

        [Required]
        [Display(Name = "Years of Experience")]
        public int YearsExperience { get; set; }
    }
}
