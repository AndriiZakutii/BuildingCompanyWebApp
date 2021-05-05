using System;
using System.Collections.Generic;

#nullable disable

namespace BuildingCompanyWebApp.Models
{
    public partial class TaskType
    {
        public TaskType()
        {
            ProjectTasks = new HashSet<ProjectTask>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProjectTask> ProjectTasks { get; set; }
    }
}
