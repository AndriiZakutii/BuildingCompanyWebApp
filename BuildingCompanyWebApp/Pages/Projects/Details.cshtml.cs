using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.Projects
{
    public class DetailsModel : PageModel
    {
        private readonly BuildingCompanyWebApp.Models.BuildingCompanyManagementContext _context;

        public DetailsModel(BuildingCompanyWebApp.Models.BuildingCompanyManagementContext context)
        {
            _context = context;
        }

        public Project Project { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Projects
                .Include(p => p.ProjectStatus)
                .Include(p => p.ProjectTasks).ThenInclude(c => c.Employments).ThenInclude(c => c.Employee).ThenInclude(c => c.Department)
                .Include(p => p.ProjectTasks).ThenInclude(c => c.Employments).ThenInclude(c => c.Employee).ThenInclude(c => c.EmployeePosition)
                .Include(p => p.ProjectTasks).ThenInclude(c => c.Employments).ThenInclude(c => c.Employee).ThenInclude(c => c.Gender)
                .Include(p => p.ProjectTasks).ThenInclude(c => c.TaskType)
                .Include(p => p.ProjectType).FirstOrDefaultAsync(m => m.Id == id);

            if (Project == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
