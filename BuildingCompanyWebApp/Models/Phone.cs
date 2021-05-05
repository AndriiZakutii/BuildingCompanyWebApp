using System;
using System.Collections.Generic;

#nullable disable

namespace BuildingCompanyWebApp.Models
{
    public partial class Phone
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int InvestorId { get; set; }

        public virtual IndividualInvestor Investor { get; set; }
    }
}
