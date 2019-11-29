import { Injectable } from "@angular/core";
import { Team } from "../models/team.model";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})
export class TeamService {
  team: Team;
  teams: Array<Team>;
  private readonly rootUrl = "http://localhost:52991/api/team";

  constructor(private http: HttpClient) {}

  allTeams() {
    this.http
      .get<Array<Team>>(this.rootUrl + "/getall")
      .toPromise()
      .then(response => (this.teams = response as Array<Team>));
  }

  save(team: Team) {
    return this.http.post(this.rootUrl + "/save", team);
  }

  update(id: Number, team: Team) {
    return this.http.put(this.rootUrl + "/update/" + id, team);
  }

  delete(id: Number) {
    return this.http.delete(this.rootUrl + "/delete/" + id);
  }
}
