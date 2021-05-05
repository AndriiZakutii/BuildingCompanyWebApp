using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.ConstructionObjects
{
    public class IndexModel : PageModel
    {
        private readonly BuildingCompanyWebApp.Models.BuildingCompanyManagementContext _context;

        public IndexModel(BuildingCompanyWebApp.Models.BuildingCompanyManagementContext context)
        {
            _context = context;
        }

        public IList<ConstructionObject> ConstructionObject { get;set; }

        public async Task OnGetAsync()
        {
            ConstructionObject = await _context.ConstructionObjects
                .Include(c => c.ConstructionObjectType)
                .Include(c => c.Location)
                .Include(c => c.Project).ToListAsync();
        }
    }
}
