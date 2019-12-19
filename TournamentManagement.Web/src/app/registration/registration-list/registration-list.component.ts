import { Component, OnInit } from "@angular/core";
import { RegistrationService } from "src/app/shared/services/registration.service";
import { ToastrService } from "ngx-toastr";
import { TournamentService } from "src/app/shared/services/tournament.service";

@Component({
  selector: "app-registration-list",
  templateUrl: "./registration-list.component.html",
  styles: []
})
export class RegistrationListComponent implements OnInit {
  constructor(
    private service: RegistrationService,
    private tournamentService: TournamentService,
    private toastr: ToastrService
  ) {}

  tournamentId: Number = 0;
  ngOnInit() {
    this.tournamentService.allTournaments();
  }

  getRegisteredTeams() {
    this.service.getByTournament(this.tournamentId);
  }
}
