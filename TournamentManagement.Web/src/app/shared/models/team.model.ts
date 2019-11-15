export class Team {
    Id: Number;
    Name: String;
    Coach: String;
    Captain: String;

    constructor(name: String, coach: String, captain: String) {
        this.Name = name;
        this.Coach = coach;
        this.Captain = captain;
    }
}
