export class Tournament {
    Id: Number;
    Name: String;
    StartDate: Date;
    Location: String;

    constructor(name: String, startDate: Date, location: String) {
        this.Name = name;
        this.StartDate = startDate;
        this.Location = location;
    }
}
