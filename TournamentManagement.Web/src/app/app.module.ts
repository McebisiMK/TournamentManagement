import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { AngularFontAwesomeModule } from "angular-font-awesome";
import { TabsModule } from "ngx-bootstrap/tabs";
import { ToastrModule } from "ngx-toastr";
import { AppComponent } from "./app.component";
import { HeaderComponent } from "./header/header.component";
import { TournamentService } from "./shared/services/tournament.service";
import { TeamService } from "./shared/services/team.service";
import { RegistrationService } from "./shared/services/registration.service";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";
import { DateInputsModule } from "@progress/kendo-angular-dateinputs";
import { TeamsComponent } from "./teams/teams.component";
import { RegisterTeamComponent } from "./teams/register-team/register-team.component";
import { TeamListComponent } from "./teams/team-list/team-list.component";
import { TournamentsComponent } from "./tournaments/tournaments.component";
import { RegisterTournamentComponent } from "./tournaments/register-tournament/register-tournament.component";
import { TournamentListComponent } from "./tournaments/tournament-list/tournament-list.component";
import { RegistrationComponent } from './registration/registration.component';
import { RegisterComponent } from './registration/register/register.component';
import { RegistrationListComponent } from './registration/registration-list/registration-list.component';

const appRoutes: Routes = [
  { path: "", redirectTo: "tournaments", pathMatch: "full" },
  { path: "tournaments", component: TournamentsComponent },
  { path: "teams", component: TeamsComponent },
  { path: "registration", component: RegistrationComponent }
];
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    TeamsComponent,
    RegisterTeamComponent,
    TeamListComponent,
    TournamentsComponent,
    RegisterTournamentComponent,
    TournamentListComponent,
    RegistrationComponent,
    RegisterComponent,
    RegistrationListComponent
  ],
  imports: [
    RouterModule.forRoot(appRoutes),
    BrowserModule,
    BrowserAnimationsModule,
    TabsModule.forRoot(),
    ToastrModule.forRoot(),
    AngularFontAwesomeModule,
    NgbModule,
    HttpClientModule,
    FormsModule,
    DateInputsModule
  ],
  providers: [TournamentService, TeamService, RegistrationService],
  bootstrap: [AppComponent]
})
export class AppModule {}
