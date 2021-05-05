using System;
using System.Collections.Generic;

#nullable disable

namespace BuildingCompanyWebApp.Models
{
    public partial class CompanyPhone
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int CompanyInvestorId { get; set; }

        public virtual CompanyInvestor CompanyInvestor { get; set; }
    }
}
