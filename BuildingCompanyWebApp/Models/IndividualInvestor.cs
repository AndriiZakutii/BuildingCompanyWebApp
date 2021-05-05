using System;
using System.Collections.Generic;

#nullable disable

namespace BuildingCompanyWebApp.Models
{
    public partial class IndividualInvestor
    {
        public IndividualInvestor()
        {
            Phones = new HashSet<Phone>();
        }

        public int Id { get; set; }
        public int NationalityId { get; set; }
        public int GenderId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? PassportfExpireDate { get; set; }
        public string PassportNumber { get; set; }
        public string PassportAuthority { get; set; }
        public DateTime? PassportIssueDate { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual Investor IdNavigation { get; set; }
        public virtual Nationality Nationality { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
