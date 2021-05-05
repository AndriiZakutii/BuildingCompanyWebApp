using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.IndividualInvestors
{
    public class DetailsModel : PageModel
    {
        private readonly BuildingCompanyWebApp.Models.BuildingCompanyManagementContext _context;

        public DetailsModel(BuildingCompanyWebApp.Models.BuildingCompanyManagementContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
