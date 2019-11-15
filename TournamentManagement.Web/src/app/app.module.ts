import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule  } from "@angular/platform-browser/animations";
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from "@angular/router";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DatepickerModule, BsDatepickerModule } from 'ngx-bootstrap/datepicker';
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
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";
import { RegisterComponent } from './tournaments/register/register.component';
import { TournamentsListComponent } from './tournaments/tournaments-list/tournaments-list.component';

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
    PlayersComponent,
    RegisterComponent,
    TournamentsListComponent
  ],
  imports: [
    RouterModule.forRoot(appRoutes),
    BrowserModule,
    BrowserAnimationsModule ,
    TabsModule.forRoot(),
    BsDatepickerModule.forRoot(),
    DatepickerModule.forRoot(),
    AngularFontAwesomeModule,
    NgbModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [TournamentService, TeamService, RegistrationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
