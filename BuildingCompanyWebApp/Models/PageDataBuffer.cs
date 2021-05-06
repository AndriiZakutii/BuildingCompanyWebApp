using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingCompanyWebApp.Models
{
    public static class PageDataBuffer
    {
        public static Dictionary<string, object> PageData = new Dictionary<string, object>
        {
            { "Employee", null },
            { "Employment", null },
            { "ProjectTask", null},
            { "Investor", null},
            { "Investment", null },
            { "Tasks", null },
        };

        public static int CurrnetTask { get; set; }
    }
}
