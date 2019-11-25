import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from "@angular/router";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ToastrModule } from "ngx-toastr";
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { TournamentsComponent } from './tournaments/tournaments.component';
import { TeamsComponent } from './teams/teams.component';
import { TournamentService } from './shared/services/tournament.service';
import { TeamService } from './shared/services/team.service';
import { RegistrationService } from './shared/services/registration.service';
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";
import { RegisterComponent } from './tournaments/register/register.component';
import { TournamentsListComponent } from './tournaments/tournaments-list/tournaments-list.component';
import { RegistrationComponent } from './teams/registration/registration.component';
import { TeamsListComponent } from './teams/teams-list/teams-list.component';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';


const appRoutes: Routes = [
  { path: '', redirectTo: 'tournaments', pathMatch: 'full' },
  { path: 'tournaments', component: TournamentsComponent },
  { path: 'teams', component: TeamsComponent }
];
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    TournamentsComponent,
    TeamsComponent,
    RegisterComponent,
    TournamentsListComponent,
    RegistrationComponent,
    TeamsListComponent
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
export class AppModule { }
