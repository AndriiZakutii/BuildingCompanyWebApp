using System;
using System.Collections.Generic;

#nullable disable

namespace BuildingCompanyWebApp.Models
{
    public partial class EmployeePhone
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Number { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
