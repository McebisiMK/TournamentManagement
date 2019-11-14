import { Component, OnInit } from '@angular/core';
import { TournamentService } from '../shared/services/tournament.service';

@Component({
  selector: 'app-tournaments',
  templateUrl: './tournaments.component.html',
  styleUrls: []
})
export class TournamentsComponent implements OnInit {

  constructor(private service: TournamentService) { }
  

  ngOnInit() {
  }

}
