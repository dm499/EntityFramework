using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication.Models;

namespace WebApplication.Pages.Employee
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
        ViewData["GenderTypeId"] = new SelectList(_context.GenderTypes, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Employees Employees { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employees.Add(Employees);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
