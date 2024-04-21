import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {

  constructor() { }

  submitForm(form: NgForm): void {
    if (form.valid) {
      // Submit form data
      console.log(form.value);
      // Here you can implement logic to send the form data to a backend server, save it locally, or perform any other action
    } else {
      // Handle form validation errors
      console.log("Form is invalid. Please check your inputs.");
    }
  }
}
