using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.PettyCash
{
    public class EditModel : PageModel
    {
        private readonly WebApplication.Models.CPC_Clone_dbContext _context;

        public EditModel(WebApplication.Models.CPC_Clone_dbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PettyCashRequests PettyCashRequests { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PettyCashRequests = await _context.PettyCashRequests
                .Include(p => p.CurrencyType)
                .Include(p => p.Employee)
                .Include(p => p.StatusType).FirstOrDefaultAsync(m => m.Id == id);

            if (PettyCashRequests == null)
            {
                return NotFound();
            }
           ViewData["CurrencyTypeId"] = new SelectList(_context.CurrencyTypes, "Id", "Description");
           ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Email");
           ViewData["StatusTypeId"] = new SelectList(_context.StatusTypes, "Id", "Description");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PettyCashRequests).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PettyCashRequestsExists(PettyCashRequests.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PettyCashRequestsExists(int id)
        {
            return _context.PettyCashRequests.Any(e => e.Id == id);
        }
    }
}
