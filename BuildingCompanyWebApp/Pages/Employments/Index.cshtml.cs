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
    public class IndexModel : PageModel
    {
        private readonly BuildingCompanyWebApp.Models.BuildingCompanyManagementContext _context;

        public IndexModel(BuildingCompanyWebApp.Models.BuildingCompanyManagementContext context)
        {
            _context = context;
        }

        public IList<Employment> Employment { get;set; }

        public async Task OnGetAsync()
        {
            Employment = await _context.Employments
                .Include(e => e.Employee)
                .Include(e => e.Role)
                .Include(e => e.Task).ToListAsync();
        }
    }
}
