using System;
using System.Collections.Generic;

#nullable disable

namespace BuildingCompanyWebApp.Models
{
    public partial class Investment
    {
        public int Id { get; set; }
        public int InvestorId { get; set; }
        public int ProjectId { get; set; }
        public decimal? Sum { get; set; }
        public DateTime? Datetime { get; set; }
        public int TaskId { get; set; }

        public virtual Investor Investor { get; set; }
        public virtual Project Project { get; set; }
        public virtual ProjectTask Task { get; set; }
    }
}
