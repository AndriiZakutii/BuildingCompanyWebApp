using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.IndividualInvestors
{
    public class IndexModel : PageModel
    {
        private readonly BuildingCompanyWebApp.Models.BuildingCompanyManagementContext _context;

        public IndexModel(BuildingCompanyWebApp.Models.BuildingCompanyManagementContext context)
        {
            _context = context;
        }

        public IList<IndividualInvestor> IndividualInvestor { get;set; }

        public async Task OnGetAsync()
        {
            IndividualInvestor = await _context.IndividualInvestors
                .Include(i => i.Gender)
                .Include(i => i.IdNavigation)
                .Include(i => i.Nationality).ToListAsync();
        }
    }
}
