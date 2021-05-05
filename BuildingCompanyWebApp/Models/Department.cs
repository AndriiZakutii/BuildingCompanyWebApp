using System;
using System.Collections.Generic;

#nullable disable

namespace BuildingCompanyWebApp.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
