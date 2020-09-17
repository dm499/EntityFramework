using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeList.Models
{
    public class tblSkill
    {
        [Key]
        public int SkillID { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Type of Skill")]
        public string Title { get; set; }
    }
}
