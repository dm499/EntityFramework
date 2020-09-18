﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication.Models;

namespace WebApplication.Pages.Currency
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication.Models.CPC_Clone_dbContext _context;

        public CreateModel(WebApplication.Models.CPC_Clone_dbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CurrencyTypes CurrencyTypes { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CurrencyTypes.Add(CurrencyTypes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
