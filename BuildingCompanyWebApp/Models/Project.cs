using System;
using System.Collections.Generic;

#nullable disable

namespace BuildingCompanyWebApp.Models
{
    public partial class Project
    {
        public Project()
        {
            ConstructionObjects = new HashSet<ConstructionObject>();
            Investments = new HashSet<Investment>();
            ProjectTasks = new HashSet<ProjectTask>();
        }

        public int Id { get; set; }
        public decimal? Cost { get; set; }
        public DateTime? PlannedStartDate { get; set; }
        public DateTime? PlannedEndDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public int ProjectTypeId { get; set; }
        public int ProjectStatusId { get; set; }
        public string Name { get; set; }

        public virtual ProjectStatus ProjectStatus { get; set; }
        public virtual ProjectType ProjectType { get; set; }
        public virtual ICollection<ConstructionObject> ConstructionObjects { get; set; }
        public virtual ICollection<Investment> Investments { get; set; }
        public virtual ICollection<ProjectTask> ProjectTasks { get; set; }
    }
}
