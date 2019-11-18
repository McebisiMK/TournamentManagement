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

        public int Id { get; set; }

        public int TournamentId { get; set; }

        public int TeamId { get; set; }

        public decimal Amount { get; set; }

        public virtual Team Team { get; set; }
        public virtual Tournament Tournament { get; set; }
    }
}
