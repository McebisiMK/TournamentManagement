using System;
using Newtonsoft.Json;

namespace TournamentManagement.Entities.Models
{
    public class RegisteredTeam
    {
        public RegisteredTeam() { }

        public RegisteredTeam(string tournamentName, string teamName, string coach, string captain, string location, DateTime startDate, decimal amount)
        {
            TournamentName = tournamentName;
            TeamName = teamName;
            Coach = coach;
            Captain = captain;
            Location = location;
            StartDate = startDate;
            Amount = amount;
        }

        [JsonProperty("tournamentName")]
        public string TournamentName;

        [JsonProperty("teamName")]
        public string TeamName;

        [JsonProperty("coach")]
        public string Coach;

        [JsonProperty("captain")]
        public string Captain;

        [JsonProperty("location")]
        public string Location;

        [JsonProperty("startDate")]
        public DateTime StartDate;

        [JsonProperty("amount")]
        public decimal Amount;

    }
}