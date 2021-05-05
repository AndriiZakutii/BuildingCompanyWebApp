using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.Investments
{
    public class DetailsModel : PageModel
    {
        private readonly BuildingCompanyWebApp.Models.BuildingCompanyManagementContext _context;

        public DetailsModel(BuildingCompanyWebApp.Models.BuildingCompanyManagementContext context)
        {
            _context = context;
        }

        public Investment Investment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Investment = await _context.Investments
                .Include(i => i.Investor)
                .Include(i => i.Project)
                .Include(i => i.Task).FirstOrDefaultAsync(m => m.Id == id);

            if (Investment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
