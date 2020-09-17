using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.Employee
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication.Models.CPC_Clone_dbContext _context;

        public IndexModel(WebApplication.Models.CPC_Clone_dbContext context)
        {
            _context = context;
        }

        public IList<Employees> Employees { get;set; }

        public async Task OnGetAsync()
        {
            Employees = await _context.Employees
                .Include(e => e.GenderType).ToListAsync();
        }
    }
}
