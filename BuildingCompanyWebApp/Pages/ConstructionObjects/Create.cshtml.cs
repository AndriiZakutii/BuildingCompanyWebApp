using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.ConstructionObjects
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
        ViewData["ConstructionObjectTypeId"] = new SelectList(_context.ConstructionObjectTypes, "Id", "Id");
        ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id");
        ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public ConstructionObject ConstructionObject { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ConstructionObjects.Add(ConstructionObject);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
