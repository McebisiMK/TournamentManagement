using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TournamentManagement.Entities.Models
{
    public partial class Registration
    {
        public Registration() { }
        public Registration(int tournamentId, int teamId, decimal amount)
        {
            TournamentId = tournamentId;
            TeamId = teamId;
            Amount = amount;
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("tournamentId")]
        public int TournamentId { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        public virtual Team Team { get; set; }
        public virtual Tournament Tournament { get; set; }
    }
}
