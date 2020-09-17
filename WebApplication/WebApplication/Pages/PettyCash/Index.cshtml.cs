using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.PettyCash
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication.Models.CPC_Clone_dbContext _context;

        public IndexModel(WebApplication.Models.CPC_Clone_dbContext context)
        {
            _context = context;
        }

        public IList<PettyCashRequests> PettyCashRequests { get;set; }

        public async Task OnGetAsync()
        {
            PettyCashRequests = await _context.PettyCashRequests
                .Include(p => p.CurrencyType)
                .Include(p => p.Employee)
                .Include(p => p.StatusType).ToListAsync();
        }
    }
}
