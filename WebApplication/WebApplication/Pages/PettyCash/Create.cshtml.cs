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
        ViewData["CurrencyTypeId"] = new SelectList(_context.CurrencyTypes, "Id", "Name");
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName");
        ViewData["StatusTypeId"] = new SelectList(_context.StatusTypes, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public PettyCashRequests PettyCashRequests { get; set; }

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
