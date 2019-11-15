import { Injectable } from '@angular/core';
import { Tournament } from '../models/tournament.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class TournamentService {
  tournament: Tournament;
  private readonly rootUrl = 'http://localhost:61418/api/tournament';

  constructor(private http: HttpClient) { }

  save(tournament: Tournament) {
    return this.http.post(this.rootUrl + '/save', tournament)
  }
}
