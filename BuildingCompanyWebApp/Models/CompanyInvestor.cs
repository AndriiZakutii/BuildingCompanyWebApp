using System;
using System.Collections.Generic;

#nullable disable

namespace BuildingCompanyWebApp.Models
{
    public partial class CompanyInvestor
    {
        public CompanyInvestor()
        {
            CompanyPhones = new HashSet<CompanyPhone>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyTypeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime? FoundationDatetime { get; set; }

        public virtual CompanyType CompanyType { get; set; }
        public virtual Investor IdNavigation { get; set; }
        public virtual ICollection<CompanyPhone> CompanyPhones { get; set; }
    }
}
