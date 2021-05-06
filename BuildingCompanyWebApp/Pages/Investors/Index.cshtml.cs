using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingCompanyWebApp.Models;

namespace BuildingCompanyWebApp.Pages.Investors
{
    public class IndexModel : PageModel
    {
        private readonly BuildingCompanyManagementContext _context;

        public IndexModel(BuildingCompanyManagementContext context)
        {
            _context = context;
        }

        public IList<Investor> Investor { get;set; }
        public IEnumerable<IndividualInvestor> IndividualInvestors => _context.IndividualInvestors;
        public IEnumerable<CompanyInvestor> CompanyInvestors => _context.CompanyInvestors.Include(e => e.CompanyType);

        public async Task OnGetAsync()
        {
            Investor = await _context.Investors.ToListAsync();
        }
    }
}
