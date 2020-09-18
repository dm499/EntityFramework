using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.PettyCash
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication.Models.CPC_Clone_dbContext _context;

        public DetailsModel(WebApplication.Models.CPC_Clone_dbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
