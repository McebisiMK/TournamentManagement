import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from "@angular/router";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { TournamentsComponent } from './tournaments/tournaments.component';
import { HomeComponent } from './home/home.component';
import { TeamsComponent } from './teams/teams.component';
import { TableComponent } from './teams/table/table.component';
import { MatchesComponent } from './teams/matches/matches.component';
import { PlayersComponent } from './teams/players/players.component';
import { TournamentService } from './shared/services/tournament.service';
import { TeamService } from './shared/services/team.service';
import { RegistrationService } from './shared/services/registration.service';

const appRoutes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'tournaments', component: TournamentsComponent },
  { path: 'teams', component: TeamsComponent }
];
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    TournamentsComponent,
    HomeComponent,
    TeamsComponent,
    TableComponent,
    MatchesComponent,
    PlayersComponent
  ],
  imports: [
    RouterModule.forRoot(appRoutes),
    BrowserModule,
    TabsModule.forRoot(),
    AngularFontAwesomeModule,
    NgbModule
  ],
  providers: [TournamentService, TeamService, RegistrationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
