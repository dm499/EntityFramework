using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.StatusPage
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication.Models.CPC_Clone_dbContext _context;

        public DetailsModel(WebApplication.Models.CPC_Clone_dbContext context)
        {
            _context = context;
        }

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
    }
}
