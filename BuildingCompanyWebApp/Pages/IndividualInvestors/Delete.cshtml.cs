using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.IndividualInvestors
{
    public class DeleteModel : PageModel
    {
        private readonly BuildingCompanyManagementContext _context;

        public DeleteModel(BuildingCompanyManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IndividualInvestor IndividualInvestor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IndividualInvestor = await _context.IndividualInvestors
                .Include(i => i.Gender)
                .Include(i => i.IdNavigation)
                .Include(i => i.Nationality).FirstOrDefaultAsync(m => m.Id == id);

            if (IndividualInvestor == null)
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

            IndividualInvestor = await _context.IndividualInvestors.FindAsync(id);

            if (IndividualInvestor != null)
            {
                _context.IndividualInvestors.Remove(IndividualInvestor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Investors/Index");
        }
    }
}
