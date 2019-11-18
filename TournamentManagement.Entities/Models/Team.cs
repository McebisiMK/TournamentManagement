using System.Collections.Generic;

namespace TournamentManagement.Entities.Models
{
    public partial class Team
    {
        public Team()
        {
            Registration = new HashSet<Registration>();
        }

        public Team(string name, string coach, string captain)
        {
            Name = name;
            Coach = coach;
            Captain = captain;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Coach { get; set; }

        public string Captain { get; set; }

        public virtual ICollection<Registration> Registration { get; set; }
    }
}
