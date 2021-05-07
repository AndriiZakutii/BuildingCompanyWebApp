using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BuildingCompanyWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildingCompanyWebApp.Pages.Employments
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name");
            ViewData["RoleId"] = new SelectList(_context.EmployeeRoles, "Id", "Name");
            ViewData["TaskId"] = new SelectList(_context.ProjectTasks.Where(task => ((Project)PageDataBuffer.PageData["Project"]).ProjectTasks.Contains(task)).Include(e => e.TaskType), "Id", "TaskType.Name");
            return Page();
        }

        [BindProperty]
        public Employment Employment { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Employment.Id = _context.Employments.Max(e => e.Id) + 1;
            _context.Employments.Add(Employment);
            await _context.SaveChangesAsync();

            return RedirectToPage(Services.PageNavigator.PreviousPageName, new { id = Services.PageNavigator.PreviousId });
        }
    }
}
