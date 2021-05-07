using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.CompanyInvestors
{
    public class CreateModel : PageModel
    {
        private readonly BuildingCompanyManagementContext _context;

        public CreateModel(BuildingCompanyManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CompanyTypeId"] = new SelectList(_context.CompanyTypes, "Id", "Name");
            ViewData["Id"] = new SelectList(_context.Investors, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public CompanyInvestor CompanyInvestor { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            CompanyInvestor.Id = _context.CompanyInvestors.Max(e => e.Id) + 1;
            _context.CompanyInvestors.Add(CompanyInvestor);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Investors/Index");
        }
    }
}
