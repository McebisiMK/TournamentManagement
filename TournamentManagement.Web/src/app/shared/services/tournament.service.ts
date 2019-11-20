import { Injectable } from "@angular/core";
import { Tournament } from "../models/tournament.model";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})
export class TournamentService {
  tournament: Tournament;
  tournaments: Array<Tournament>;
  private readonly rootUrl = "http://localhost:61418/api/tournament";

  constructor(private http: HttpClient) { }

  allTournaments() {
    this.http
      .get<Array<Tournament>>(this.rootUrl + "/getall")
      .toPromise()
      .then(response => (this.tournaments = response as Array<Tournament>));
  }

  save(tournament: Tournament) {
    return this.http.post(this.rootUrl + "/save", tournament);
  }

  update(id: Number, tournament: Tournament) {
    return this.http.put(this.rootUrl + "/update/" + id, tournament);
  }
}
