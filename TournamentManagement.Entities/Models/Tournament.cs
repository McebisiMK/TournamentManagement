using System;
using System.Collections.Generic;

namespace TournamentManagement.Entities.Models
{
    public partial class Tournament
    {
        public Tournament()
        {
            Registration = new HashSet<Registration>();
        }

        public Tournament(string name, DateTime startDate, string location)
        {
            Name = name;
            StartDate = startDate;
            Location = location;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public string Location { get; set; }

        public virtual ICollection<Registration> Registration { get; set; }
    }
}
