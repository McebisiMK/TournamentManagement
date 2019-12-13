import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Registration } from "../models/registration.model";

@Injectable({
  providedIn: "root"
})
export class RegistrationService {
  registration: Registration;
  private readonly rootUrl = "http://localhost:61418/api/registration";

  constructor(private http: HttpClient) {}

  save(registration: Registration) {
    return this.http.post(this.rootUrl + "/save", registration);
  }

  update(id: Number, registration: Registration) {
    return this.http.put(this.rootUrl + "/update/" + id, registration);
  }

  delete(id: Number) {
    return this.http.delete(this.rootUrl + "/delete/" + id);
  }
}
