using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BuildingCompanyWebApp.Pages.Shared
{
    public class _PageStartModel : PageModel
    {
        public Dictionary<string, object> PageData = new Dictionary<string, object>
        {
            { "Employee", null },
            { "Employment", null },
            { "ProjectTask", null},
            { "Investor", null},
            { "Investment", null }
        };

        public void OnGet()
        {
        }
    }
}
