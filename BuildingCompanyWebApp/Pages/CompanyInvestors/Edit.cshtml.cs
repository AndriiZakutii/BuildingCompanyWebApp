using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.CompanyInvestors
{
    public class EditModel : PageModel
    {
        private readonly BuildingCompanyManagementContext _context;

        public EditModel(BuildingCompanyManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CompanyInvestor CompanyInvestor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CompanyInvestor = await _context.CompanyInvestors
                .Include(c => c.CompanyType)
                .Include(c => c.IdNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (CompanyInvestor == null)
            {
                return NotFound();
            }
           ViewData["CompanyTypeId"] = new SelectList(_context.CompanyTypes, "Id", "Name");
           ViewData["Id"] = new SelectList(_context.Investors, "Id", "Name");
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

            _context.Attach(CompanyInvestor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyInvestorExists(CompanyInvestor.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Investors/Index");
        }

        private bool CompanyInvestorExists(int id)
        {
            return _context.CompanyInvestors.Any(e => e.Id == id);
        }
    }
}
