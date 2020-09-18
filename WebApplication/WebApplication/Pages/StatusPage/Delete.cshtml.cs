using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.StatusPage
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication.Models.CPC_Clone_dbContext _context;

        public DeleteModel(WebApplication.Models.CPC_Clone_dbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StatusTypes StatusTypes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StatusTypes = await _context.StatusTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (StatusTypes == null)
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

            StatusTypes = await _context.StatusTypes.FindAsync(id);

            if (StatusTypes != null)
            {
                _context.StatusTypes.Remove(StatusTypes);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
