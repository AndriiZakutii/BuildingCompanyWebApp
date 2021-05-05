using System;
using System.Collections.Generic;

#nullable disable

namespace BuildingCompanyWebApp.Models
{
    public partial class ConstructionObject
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int ConstructionObjectTypeId { get; set; }
        public int ProjectId { get; set; }
        public string Discription { get; set; }

        public virtual ConstructionObjectType ConstructionObjectType { get; set; }
        public virtual Location Location { get; set; }
        public virtual Project Project { get; set; }
    }
}
