using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication.Models;

namespace WebApplication.Pages.Gender
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication.Models.CPC_Clone_dbContext _context;

        public CreateModel(WebApplication.Models.CPC_Clone_dbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GenderTypes GenderTypes { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GenderTypes.Add(GenderTypes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
