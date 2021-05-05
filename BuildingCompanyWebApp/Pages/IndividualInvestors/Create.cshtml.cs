using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.IndividualInvestors
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
        ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Id");
        ViewData["Id"] = new SelectList(_context.Investors, "Id", "Id");
        ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public IndividualInvestor IndividualInvestor { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.IndividualInvestors.Add(IndividualInvestor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
