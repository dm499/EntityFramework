using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.Log
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication.Models.CPC_Clone_dbContext _context;

        public DeleteModel(WebApplication.Models.CPC_Clone_dbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TransactionLogs = await _context.TransactionLogs.FindAsync(id);

            if (TransactionLogs != null)
            {
                _context.TransactionLogs.Remove(TransactionLogs);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
