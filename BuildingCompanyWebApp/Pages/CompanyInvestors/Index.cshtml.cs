using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.CompanyInvestors
{
    public class IndexModel : PageModel
    {
        private readonly BuildingCompanyWebApp.Models.BuildingCompanyManagementContext _context;

        public IndexModel(BuildingCompanyWebApp.Models.BuildingCompanyManagementContext context)
        {
            _context = context;
        }

        public IList<CompanyInvestor> CompanyInvestor { get;set; }

        public async Task OnGetAsync()
        {
            CompanyInvestor = await _context.CompanyInvestors
                .Include(c => c.CompanyType)
                .Include(c => c.IdNavigation).ToListAsync();
        }
    }
}
