import { Component, OnInit } from '@angular/core';
import { TournamentService } from 'src/app/shared/services/tournament.service';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-register-tournament',
  templateUrl: './register-tournament.component.html',
  styles: []
})
export class RegisterTournamentComponent implements OnInit {
  constructor(
    private service: TournamentService,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.resetForm();
  }

  onSubmit(form: NgForm) {
    if (form.value.id == 0) {
      this.saveRecord(form);
    } else {
      this.updateRecord(form);
    }
  }

  saveRecord(form: NgForm) {
    this.service.save(form.value).subscribe(
      response => {
        this.toastr.success("Record inserted successfully", "Tournament");
        this.resetForm(form);
        this.service.allTournaments();
      },
      error => {
        console.log(error);
      }
    );
  }

  updateRecord(form: NgForm) {
    this.service.update(form.value.id, form.value).subscribe(
      response => {
        this.toastr.success("Record updated successfully", "Tournament");
        this.resetForm(form);
        this.service.allTournaments();
      },
      error => {
        console.log(error);
      }
    );
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
    this.service.tournament = {
      id: 0,
      name: "",
      location: "",
      startDate: new Date()
    };
  }
}
