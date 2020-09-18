using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.Gender
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication.Models.CPC_Clone_dbContext _context;

        public DetailsModel(WebApplication.Models.CPC_Clone_dbContext context)
        {
            _context = context;
        }

        public GenderTypes GenderTypes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GenderTypes = await _context.GenderTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (GenderTypes == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
