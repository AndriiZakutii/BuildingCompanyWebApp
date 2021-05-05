using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.Investors
{
    public class EditModel : PageModel
    {
        private readonly BuildingCompanyWebApp.Models.BuildingCompanyManagementContext _context;

        public EditModel(BuildingCompanyWebApp.Models.BuildingCompanyManagementContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Investor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestorExists(Investor.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InvestorExists(int id)
        {
            return _context.Investors.Any(e => e.Id == id);
        }
    }
}
