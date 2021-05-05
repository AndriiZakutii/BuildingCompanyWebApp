using System;
using System.Collections.Generic;

#nullable disable

namespace BuildingCompanyWebApp.Models
{
    public partial class Investor
    {
        public Investor()
        {
            Investments = new HashSet<Investment>();
        }

        public int Id { get; set; }

        public virtual CompanyInvestor CompanyInvestor { get; set; }
        public virtual IndividualInvestor IndividualInvestor { get; set; }
        public virtual ICollection<Investment> Investments { get; set; }
    }
}
