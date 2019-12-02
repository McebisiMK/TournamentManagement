import { Component, OnInit } from "@angular/core";
import { TeamService } from "src/app/shared/services/team.service";
import { Team } from "src/app/shared/models/team.model";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: "app-teams-list",
  templateUrl: "./teams-list.component.html",
  styles: []
})
export class TeamsListComponent implements OnInit {
  constructor(private service: TeamService, private toastr: ToastrService) {}

  ngOnInit() {
    this.service.allTeams();
  }

  fillForm(team: Team) {
    this.service.team = Object.assign({}, team);
  }

  delete(id: Number) {
    if (confirm("Confirm deletion of team")) {
      this.service.delete(id).subscribe(
        response => {
          this.toastr.warning("Team deleted successfully", "Team");
        },
        error => {
          console.log(error);
        }
      );
    }
  }
}
