using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.Investors
{
    public class DetailsModel : PageModel
    {
        private readonly BuildingCompanyManagementContext _context;

        public DetailsModel(BuildingCompanyManagementContext context)
        {
            _context = context;
        }

        public Investor Investor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Investor = await _context.Investors.FirstOrDefaultAsync(m => m.Id == id);

            if (Investor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
