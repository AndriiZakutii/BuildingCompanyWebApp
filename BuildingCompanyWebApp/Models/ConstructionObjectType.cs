using System;
using System.Collections.Generic;

#nullable disable

namespace BuildingCompanyWebApp.Models
{
    public partial class ConstructionObjectType
    {
        public ConstructionObjectType()
        {
            ConstructionObjects = new HashSet<ConstructionObject>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ConstructionObject> ConstructionObjects { get; set; }
    }
}
