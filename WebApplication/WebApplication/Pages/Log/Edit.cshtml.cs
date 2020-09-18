using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.Log
{
    public class EditModel : PageModel
    {
        private readonly WebApplication.Models.CPC_Clone_dbContext _context;

        public EditModel(WebApplication.Models.CPC_Clone_dbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TransactionLogs TransactionLogs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TransactionLogs = await _context.TransactionLogs.FirstOrDefaultAsync(m => m.Id == id);

            if (TransactionLogs == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TransactionLogs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionLogsExists(TransactionLogs.Id))
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

        private bool TransactionLogsExists(int id)
        {
            return _context.TransactionLogs.Any(e => e.Id == id);
        }
    }
}
