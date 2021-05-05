using System;
using System.Collections.Generic;

#nullable disable

namespace BuildingCompanyWebApp.Models
{
    public partial class Location
    {
        public Location()
        {
            ConstructionObjects = new HashSet<ConstructionObject>();
            Departments = new HashSet<Department>();
        }

        public int Id { get; set; }
        public string Country { get; set; }
        public string Settlement { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public int? Flat { get; set; }

        public virtual ICollection<ConstructionObject> ConstructionObjects { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}
