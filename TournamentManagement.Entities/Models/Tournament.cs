using Newtonsoft.Json;
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

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        public virtual ICollection<Registration> Registration { get; set; }
    }
}
