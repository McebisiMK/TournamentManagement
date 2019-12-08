import { Component, OnInit } from "@angular/core";
import { RegistrationService } from "src/app/shared/services/registration.service";
import { TournamentService } from "src/app/shared/services/tournament.service";
import { TeamService } from "src/app/shared/services/team.service";
import { NgForm } from "@angular/forms";
import { ToastrService } from "ngx-toastr";
import { Registration } from "src/app/shared/models/registration.model";

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styles: []
})
export class RegisterComponent implements OnInit {
  constructor(
    private registrationService: RegistrationService,
    private tournamentService: TournamentService,
    private teamService: TeamService,
    private toastr: ToastrService
  ) {}
  registration: Registration;

  ngOnInit() {
    this.tournamentService.allTournaments();
    this.teamService.allTeams();
    this.resetForm();
  }

  onSubmit(form: NgForm) {
    this.createRegistration(form);
    if (this.registration.id == 0) {
      this.saveRecord(this.registration);
    } else {
      this.updateRecord(this.registration);
    }
  }

  saveRecord(registration: Registration) {
    this.registrationService.save(registration).subscribe(
      response => {
        this.toastr.success("Team registered successfully", "Registration");
        this.resetForm();
      },
      error => {
        console.log(error);
      }
    );
  }

  updateRecord(registration: Registration) {
    this.registrationService.update(registration.id, registration).subscribe(
      response => {
        this.toastr.success(
          "Registration updated successfully",
          "Registration"
        );
        this.resetForm();
      },
      error => {
        console.log(error);
      }
    );
  }

  createRegistration(form: NgForm) {
    this.registration = {
      id: Number(form.value.id),
      tournamentId: Number(form.value.tournamentId),
      teamId: Number(form.value.teamId),
      amount: Number(form.value.amount)
    };
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }

    this.registrationService.registration = {
      id: 0,
      tournamentId: 0,
      teamId: 0,
      amount: 0
    };
  }
}
