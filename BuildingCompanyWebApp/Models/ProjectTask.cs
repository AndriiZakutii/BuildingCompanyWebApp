using System;
using System.Collections.Generic;

#nullable disable

namespace BuildingCompanyWebApp.Models
{
    public partial class ProjectTask
    {
        public ProjectTask()
        {
            Employments = new HashSet<Employment>();
            Investments = new HashSet<Investment>();
        }

        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int TaskTypeId { get; set; }
        public decimal? Cost { get; set; }
        public DateTime? PlannedStartDatetime { get; set; }
        public DateTime? PlannedEndDatetime { get; set; }
        public DateTime? StartDatetime { get; set; }
        public DateTime? EndDatetime { get; set; }
        public string Description { get; set; }

        public virtual Project Project { get; set; }
        public virtual TaskType TaskType { get; set; }
        public virtual ICollection<Employment> Employments { get; set; }
        public virtual ICollection<Investment> Investments { get; set; }
    }
}
