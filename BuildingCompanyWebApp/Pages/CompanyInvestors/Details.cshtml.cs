using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.CompanyInvestors
{
    public class DetailsModel : PageModel
    {
        private readonly BuildingCompanyWebApp.Models.BuildingCompanyManagementContext _context;

        public DetailsModel(BuildingCompanyWebApp.Models.BuildingCompanyManagementContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
