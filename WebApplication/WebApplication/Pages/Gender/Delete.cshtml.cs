﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.Gender
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication.Models.CPC_Clone_dbContext _context;

        public DeleteModel(WebApplication.Models.CPC_Clone_dbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GenderTypes = await _context.GenderTypes.FindAsync(id);

            if (GenderTypes != null)
            {
                _context.GenderTypes.Remove(GenderTypes);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
