using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.ConstructionObjects
{
    public class DetailsModel : PageModel
    {
        private readonly BuildingCompanyWebApp.Models.BuildingCompanyManagementContext _context;

        public DetailsModel(BuildingCompanyWebApp.Models.BuildingCompanyManagementContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
