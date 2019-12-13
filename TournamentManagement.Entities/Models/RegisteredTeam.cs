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

        public string TournamentName { get; set; }

        public string TeamName { get; set; }

        public string Location { get; set; }

        public DateTime StartDate { get; set; }

        public decimal Amount { get; set; }

    }
}