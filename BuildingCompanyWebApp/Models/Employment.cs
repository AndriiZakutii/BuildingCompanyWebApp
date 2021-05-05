using System;
using System.Collections.Generic;

#nullable disable

namespace BuildingCompanyWebApp.Models
{
    public partial class Employment
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int TaskId { get; set; }
        public int RoleId { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual EmployeeRole Role { get; set; }
        public virtual ProjectTask Task { get; set; }
    }
}
