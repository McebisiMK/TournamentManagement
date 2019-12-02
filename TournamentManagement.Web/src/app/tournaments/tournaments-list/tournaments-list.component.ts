import { ToastrService } from "ngx-toastr";
import { Component, OnInit } from "@angular/core";
import { TournamentService } from "src/app/shared/services/tournament.service";
import { Tournament } from "src/app/shared/models/tournament.model";

@Component({
  selector: "app-tournaments-list",
  templateUrl: "./tournaments-list.component.html",
  styles: []
})
export class TournamentsListComponent implements OnInit {
  constructor(
    private service: TournamentService,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.service.allTournaments();
  }

  fillForm(tournament: Tournament) {
    this.service.tournament = Object.assign({}, tournament);
  }

  delete(id: Number) {
    if (confirm("Confirm deletion of tournament")) {
      this.service.delete(id).subscribe(
        response => {
          this.toastr.warning("Tournament deleted successfully", "Tournament");
        },
        error => {
          console.log(error);
        }
      );
    }
  }
}
