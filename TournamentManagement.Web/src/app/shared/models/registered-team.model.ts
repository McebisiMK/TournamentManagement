export class RegisteredTeam {
    TournamentName: String;
    TeamName: String;
    Coach: String;
    Captain: String;
    Location: String;
    StartDate: Date;
    Amount: Number;

    constructor(tournamentName: String, teamName: String, coach: String, captain: String, location: String, startDate: Date, amount: Number) {
        this.TournamentName = tournamentName;
        this.TeamName = teamName;
        this.Coach = coach;
        this.Captain = captain;
        this.Location = location;
        this.StartDate = startDate;
        this.Amount = amount;
    }
}
