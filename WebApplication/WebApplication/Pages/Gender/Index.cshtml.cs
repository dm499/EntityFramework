using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.Gender
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication.Models.CPC_Clone_dbContext _context;

        public IndexModel(WebApplication.Models.CPC_Clone_dbContext context)
        {
            _context = context;
        }

        public IList<GenderTypes> GenderTypes { get;set; }

        public async Task OnGetAsync()
        {
            GenderTypes = await _context.GenderTypes.ToListAsync();
        }
    }
}
