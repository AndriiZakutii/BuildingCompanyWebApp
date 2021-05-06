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
        private readonly BuildingCompanyManagementContext _context;

        public CreateModel(BuildingCompanyManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Name");
            ViewData["Id"] = new SelectList(_context.Investors, "Id", "Name");
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "Name");
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

            IndividualInvestor.Id = _context.IndividualInvestors.Max(e => e.Id) + 1;
            _context.IndividualInvestors.Add(IndividualInvestor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
