import { Component, OnInit } from "@angular/core";
import { TournamentService } from "src/app/shared/services/tournament.service";
import { Tournament } from "src/app/shared/models/tournament.model";

@Component({
  selector: "app-tournaments-list",
  templateUrl: "./tournaments-list.component.html",
  styles: []
})
export class TournamentsListComponent implements OnInit {
  constructor(private service: TournamentService) { }

  ngOnInit() {
    this.service.allTournaments();
  }

  fillForm(tournament: Tournament) {
    this.service.tournament = Object.assign({}, tournament);
  }
}