using System;

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

        public string TournamentName;

        public string TeamName;

        public string Coach;

        public string Captain;

        public string Location;

        public DateTime StartDate;

        public decimal Amount;

    }
}