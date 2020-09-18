using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.StatusPage
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication.Models.CPC_Clone_dbContext _context;

        public IndexModel(WebApplication.Models.CPC_Clone_dbContext context)
        {
            _context = context;
        }

        public IList<StatusTypes> StatusTypes { get;set; }

        public async Task OnGetAsync()
        {
            StatusTypes = await _context.StatusTypes.ToListAsync();
        }
    }
}
