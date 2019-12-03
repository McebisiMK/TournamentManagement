import { NgForm } from "@angular/forms";
import { Component, OnInit } from "@angular/core";
import { TeamService } from "src/app/shared/services/team.service";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: "app-registration",
  templateUrl: "./registration.component.html",
  styles: []
})
export class RegistrationComponent implements OnInit {
  constructor(private service: TeamService, private toastr: ToastrService) {}

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
        this.toastr.success("Record inserted successflly", "Team");
        this.resetForm(form);
        this.service.allTeams();
      },
      error => {
        console.log(error);
      }
    );
  }

  updateRecord(form: NgForm) {
    this.service.update(form.value.id, form.value).subscribe(
      response => {
        this.toastr.success("Team updated successfully", "Team");
        this.resetForm(form);
        this.service.allTeams();
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

    this.service.team = {
      id: 0,
      name: "",
      coach: "",
      captain: ""
    };
  }
}
