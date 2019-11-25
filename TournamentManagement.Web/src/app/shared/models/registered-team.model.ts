export class RegisteredTeam {
  constructor(
    public tournamentName: String,
    public teamName: String,
    public coach: String,
    public captain: String,
    public location: String,
    public startDate: Date,
    public amount: Number
  ) {}
}
