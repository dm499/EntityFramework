using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.Currency
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication.Models.CPC_Clone_dbContext _context;

        public IndexModel(WebApplication.Models.CPC_Clone_dbContext context)
        {
            _context = context;
        }

        public IList<CurrencyTypes> CurrencyTypes { get;set; }

        public async Task OnGetAsync()
        {
            CurrencyTypes = await _context.CurrencyTypes.ToListAsync();
        }
    }
}
