export class Registration {
    Id: Number;
    TournamentId: Number;
    TeamId: Number;
    Amount: Number;

    constructor(tournamentId: Number, teamId: Number, amount: Number) {
        this.TournamentId = tournamentId;
        this.TeamId = teamId;
        this.Amount = amount;
    }
}
