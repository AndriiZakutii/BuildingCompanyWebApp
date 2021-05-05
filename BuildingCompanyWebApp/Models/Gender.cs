using System;
using System.Collections.Generic;

#nullable disable

namespace BuildingCompanyWebApp.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Employees = new HashSet<Employee>();
            IndividualInvestors = new HashSet<IndividualInvestor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<IndividualInvestor> IndividualInvestors { get; set; }
    }
}
