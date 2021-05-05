using System;
using System.Collections.Generic;

#nullable disable

namespace BuildingCompanyWebApp.Models
{
    public partial class CompanyType
    {
        public CompanyType()
        {
            CompanyInvestors = new HashSet<CompanyInvestor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CompanyInvestor> CompanyInvestors { get; set; }
    }
}
