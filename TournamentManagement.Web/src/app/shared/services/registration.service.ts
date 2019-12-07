import { Injectable } from '@angular/core';
import { Registration } from '../models/registration.model';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {
  registration: Registration;

  constructor() { }
}
