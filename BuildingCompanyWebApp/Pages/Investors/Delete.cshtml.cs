using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.Investors
{
    public class DeleteModel : PageModel
    {
        private readonly BuildingCompanyWebApp.Models.BuildingCompanyManagementContext _context;

        public DeleteModel(BuildingCompanyWebApp.Models.BuildingCompanyManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Investor Investor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Investor = await _context.Investors.FirstOrDefaultAsync(m => m.Id == id);

            if (Investor == null)
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

            Investor = await _context.Investors.FindAsync(id);

            if (Investor != null)
            {
                _context.Investors.Remove(Investor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
