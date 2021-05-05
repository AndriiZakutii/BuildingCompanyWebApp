using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.ConstructionObjects
{
    public class EditModel : PageModel
    {
        private readonly BuildingCompanyWebApp.Models.BuildingCompanyManagementContext _context;

        public EditModel(BuildingCompanyWebApp.Models.BuildingCompanyManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ConstructionObject ConstructionObject { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ConstructionObject = await _context.ConstructionObjects
                .Include(c => c.ConstructionObjectType)
                .Include(c => c.Location)
                .Include(c => c.Project).FirstOrDefaultAsync(m => m.Id == id);

            if (ConstructionObject == null)
            {
                return NotFound();
            }
           ViewData["ConstructionObjectTypeId"] = new SelectList(_context.ConstructionObjectTypes, "Id", "Id");
           ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id");
           ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Id");
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

            _context.Attach(ConstructionObject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConstructionObjectExists(ConstructionObject.Id))
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

        private bool ConstructionObjectExists(int id)
        {
            return _context.ConstructionObjects.Any(e => e.Id == id);
        }
    }
}
