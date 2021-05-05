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
        private readonly BuildingCompanyWebApp.Models.BuildingCompanyManagementContext _context;

        public CreateModel(BuildingCompanyWebApp.Models.BuildingCompanyManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CompanyTypeId"] = new SelectList(_context.CompanyTypes, "Id", "Id");
        ViewData["Id"] = new SelectList(_context.Investors, "Id", "Id");
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

            _context.CompanyInvestors.Add(CompanyInvestor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
