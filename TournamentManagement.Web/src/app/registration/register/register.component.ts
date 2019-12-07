import { Component, OnInit } from '@angular/core';
import { RegistrationService } from 'src/app/shared/services/registration.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styles: []
})
export class RegisterComponent implements OnInit {

  constructor(private service: RegistrationService) { }

  tourn = ['Mgudu','Zabase','Mnyolo','Sandile','Nkondlo']

  ngOnInit() {
  }

}
