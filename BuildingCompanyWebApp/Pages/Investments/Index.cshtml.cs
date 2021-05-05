using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.Investments
{
    public class IndexModel : PageModel
    {
        private readonly BuildingCompanyWebApp.Models.BuildingCompanyManagementContext _context;

        public IndexModel(BuildingCompanyWebApp.Models.BuildingCompanyManagementContext context)
        {
            _context = context;
        }

        public IList<Investment> Investment { get;set; }

        public async Task OnGetAsync()
        {
            Investment = await _context.Investments
                .Include(i => i.Investor)
                .Include(i => i.Project)
                .Include(i => i.Task).ToListAsync();
        }
    }
}
