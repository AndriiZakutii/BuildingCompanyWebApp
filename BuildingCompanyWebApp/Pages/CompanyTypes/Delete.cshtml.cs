using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.CompanyTypes
{
    public class DeleteModel : PageModel
    {
        private readonly BuildingCompanyWebApp.Models.BuildingCompanyManagementContext _context;

        public DeleteModel(BuildingCompanyWebApp.Models.BuildingCompanyManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CompanyType CompanyType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CompanyType = await _context.CompanyTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (CompanyType == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CompanyType = await _context.CompanyTypes.FindAsync(id);

            if (CompanyType != null)
            {
                _context.CompanyTypes.Remove(CompanyType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
