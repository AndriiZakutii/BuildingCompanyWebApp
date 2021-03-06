using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.ProjectTasks
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
        ViewData["ProjectId"] = new SelectList(_context.Projects.Where(p => p.Id == ((Project)PageDataBuffer.PageData["Project"]).Id), "Id", "Name");
        ViewData["TaskTypeId"] = new SelectList(_context.TaskTypes, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public ProjectTask ProjectTask { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ProjectTask.Id = _context.ProjectTasks.Max(e => e.Id) + 1;
            _context.ProjectTasks.Add(ProjectTask);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Projects/Details", new {id=Services.PageNavigator.CurrentId});
        }
    }
}
