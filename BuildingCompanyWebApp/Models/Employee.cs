using System;
using System.Collections.Generic;

#nullable disable

namespace BuildingCompanyWebApp.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeePhones = new HashSet<EmployeePhone>();
            Employments = new HashSet<Employment>();
        }

        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int EmployeePositionId { get; set; }
        public int GenderId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public decimal? Salary { get; set; }

        public virtual Department Department { get; set; }
        public virtual EmployeePosition EmployeePosition { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual ICollection<EmployeePhone> EmployeePhones { get; set; }
        public virtual ICollection<Employment> Employments { get; set; }
    }
}
