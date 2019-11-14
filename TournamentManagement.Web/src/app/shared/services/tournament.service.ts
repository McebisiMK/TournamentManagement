import { Injectable } from '@angular/core';
import { Tournament } from '../models/tournament.model';

@Injectable({
  providedIn: 'root'
})
export class TournamentService {
  tournamentData: Tournament;

  constructor() { }
}
