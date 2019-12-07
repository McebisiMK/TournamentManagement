import { Component, OnInit } from '@angular/core';
import { TeamService } from 'src/app/shared/services/team.service';
import { ToastrService } from 'ngx-toastr';
import { Team } from 'src/app/shared/models/team.model';

@Component({
  selector: 'app-team-list',
  templateUrl: './team-list.component.html',
  styles: []
})
export class TeamListComponent implements OnInit {
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
          this.service.allTeams();
        },
        error => {
          console.log(error);
        }
      );
    }
  }
}
