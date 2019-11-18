import { Injectable } from "@angular/core";
import { Team } from "../models/team.model";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})
export class TeamService {
  team: Team;
  teams: Team[];
  private readonly rootUrl = "http://localhost:58888/api/team";

  constructor(private http: HttpClient) { }

  save(team: Team) {
    return this.http.post(this.rootUrl + "/save", team);
  }

  allTeams() {
    this.http
      .get<Team[]>(this.rootUrl + "/getall")
      .toPromise()
      .then(response => (this.teams = response as Team[]));
  }
}
