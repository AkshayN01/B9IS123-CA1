import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  submitForm(form: NgForm): void {
    if (form.valid) {
      // Form is valid, submit data (you can handle this part as per your requirement)
      console.log(form.value); // You can see form values in the console
      // Here you can send the form data to your backend or perform any other actions
    } else {
      // Form is invalid, handle validation errors or show validation messages
    }
  }
}
