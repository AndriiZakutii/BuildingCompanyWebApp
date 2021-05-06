using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.IndividualInvestors
{
    public class EditModel : PageModel
    {
        private readonly BuildingCompanyManagementContext _context;

        public EditModel(BuildingCompanyManagementContext context)
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

            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Name");
            ViewData["Id"] = new SelectList(_context.Investors, "Id", "Name");
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "Name");
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

            _context.Attach(IndividualInvestor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndividualInvestorExists(IndividualInvestor.Id))
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

        private bool IndividualInvestorExists(int id)
        {
            return _context.IndividualInvestors.Any(e => e.Id == id);
        }
    }
}
