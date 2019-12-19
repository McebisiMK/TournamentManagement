export class RegisteredTeam {
  constructor(
    public tournamentName: String,
    public teamName: String,
    public location: String,
    public startDate: Date,
    public amount: Number
  ) {}
}
