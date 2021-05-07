using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.Employments
{
    public class EditModel : PageModel
    {
        private readonly BuildingCompanyWebApp.Models.BuildingCompanyManagementContext _context;

        public EditModel(BuildingCompanyWebApp.Models.BuildingCompanyManagementContext context)
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
           ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name");
           ViewData["RoleId"] = new SelectList(_context.EmployeeRoles, "Id", "Name");
           ViewData["TaskId"] = new SelectList(_context.ProjectTasks.Include(e => e.TaskType), "Id", "TaskType.Name");
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

            _context.Attach(Employment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmploymentExists(Employment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage(Services.PageNavigator.PreviousPageName, new { id = Services.PageNavigator.PreviousId });
        }

        private bool EmploymentExists(int id)
        {
            return _context.Employments.Any(e => e.Id == id);
        }
    }
}
