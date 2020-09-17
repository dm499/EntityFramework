using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication.Models;

namespace WebApplication.Pages.PettyCash
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
        ViewData["CurrencyTypeId"] = new SelectList(_context.CurrencyTypes, "Id", "Description");
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Email");
        ViewData["StatusTypeId"] = new SelectList(_context.StatusTypes, "Id", "Description");
            return Page();
        }

        [BindProperty]
        public PettyCashRequests PettyCashRequests { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PettyCashRequests.Add(PettyCashRequests);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
