import { Component, OnInit } from '@angular/core';
import { TeamService } from '../shared/services/team.service';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styles: []
})
export class TeamsComponent implements OnInit {

  constructor(private service: TeamService) { }

  ngOnInit() {
  }

}
