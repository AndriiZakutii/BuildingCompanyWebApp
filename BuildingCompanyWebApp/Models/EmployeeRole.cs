using System;
using System.Collections.Generic;

#nullable disable

namespace BuildingCompanyWebApp.Models
{
    public partial class EmployeeRole
    {
        public EmployeeRole()
        {
            Employments = new HashSet<Employment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employment> Employments { get; set; }
    }
}
