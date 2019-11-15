import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { TournamentService } from 'src/app/shared/services/tournament.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styles: []
})
export class RegisterComponent implements OnInit {

  constructor(private service: TournamentService) { }

  ngOnInit() {
    this.resetForm();
  }
  
    onSubmit(form: NgForm) {
      this.service.save(form.value)
        .subscribe(
          response => { 
            this.resetForm(form);
          },
          error => {
            console.log(error);
           }
          )
    }

  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();
    this.service.tournament = {
      Id: null,
      Name: '',
      Location: '',
      StartDate: null
    }
  }
}
