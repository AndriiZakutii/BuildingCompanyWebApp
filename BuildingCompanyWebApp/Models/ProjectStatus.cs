using System;
using System.Collections.Generic;

#nullable disable

namespace BuildingCompanyWebApp.Models
{
    public partial class ProjectStatus
    {
        public ProjectStatus()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
