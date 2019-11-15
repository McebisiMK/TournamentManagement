import { Component, OnInit } from '@angular/core';
import { TeamService } from 'src/app/shared/services/team.service';

@Component({
  selector: 'app-teams-list',
  templateUrl: './teams-list.component.html',
  styles: []
})
export class TeamsListComponent implements OnInit {

  constructor(private service: TeamService) { }

  ngOnInit() {
    this.service.allTeams();
  }

}
