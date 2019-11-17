import { Injectable } from "@angular/core";
import { Tournament } from "../models/tournament.model";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})
export class TournamentService {
  tournament: Tournament;
  tournaments: Tournament[];
  private readonly rootUrl = "http://localhost:58888/api/tournament";

  constructor(private http: HttpClient) {}

  save(tournament: Tournament) {
    return this.http.post(this.rootUrl + "/save", tournament);
  }

  allTournaments() {
    this.http
      .get<Tournament[]>(this.rootUrl + "/getall")
      .toPromise()
      .then(response => (this.tournaments = response as Tournament[]));
  }
}
