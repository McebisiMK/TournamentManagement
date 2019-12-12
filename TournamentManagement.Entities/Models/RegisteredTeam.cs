using System;

namespace TournamentManagement.Entities.Models
{
    public partial class RegisteredTeam
    {
        public RegisteredTeam() { }

        public RegisteredTeam(string tournamentName, string teamName, string location, DateTime startDate, decimal amount)
        {
            TournamentName = tournamentName;
            TeamName = teamName;
            Location = location;
            StartDate = startDate;
            Amount = amount;
        }

        public string TournamentName;

        public string TeamName;

        public string Location;

        public DateTime StartDate;

        public decimal Amount;

    }
}