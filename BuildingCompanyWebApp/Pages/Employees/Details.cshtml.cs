using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly BuildingCompanyManagementContext _context;

        public DetailsModel(BuildingCompanyManagementContext context)
        {
            _context = context;
        }

        public Employee Employee { get; set; }

        public IList<Employment> Employments => _context.Employments.Where(e => e.EmployeeId == Employee.Id)
            .Include(e => e.Role)
            .Include(e => e.Task).ThenInclude(e => e.TaskType)
            .Include(e => e.Task).ThenInclude(e => e.Project)
            .ToList();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.EmployeePosition)
                .Include(e => e.Gender).FirstOrDefaultAsync(m => m.Id == id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
