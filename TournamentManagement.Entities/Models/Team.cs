using Newtonsoft.Json;
using System;
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

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coach")]
        public string Coach { get; set; }

        [JsonProperty("captain")]
        public string Captain { get; set; }

        public virtual ICollection<Registration> Registration { get; set; }
    }
}
