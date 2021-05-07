using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.Employments
{
    public class DeleteModel : PageModel
    {
        private readonly BuildingCompanyWebApp.Models.BuildingCompanyManagementContext _context;

        public DeleteModel(BuildingCompanyWebApp.Models.BuildingCompanyManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employment Employment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employment = await _context.Employments
                .Include(e => e.Employee)
                .Include(e => e.Role)
                .Include(e => e.Task).ThenInclude(e => e.TaskType).FirstOrDefaultAsync(m => m.Id == id);

            if (Employment == null)
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

            Employment = await _context.Employments.FindAsync(id);

            if (Employment != null)
            {
                _context.Employments.Remove(Employment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage(Services.PageNavigator.PreviousPageName, new { id = Services.PageNavigator.PreviousId });
        }
    }
}
