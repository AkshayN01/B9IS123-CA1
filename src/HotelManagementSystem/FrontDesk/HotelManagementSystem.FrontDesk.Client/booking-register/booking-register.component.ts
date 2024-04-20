import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-booking-register',
  templateUrl: './booking-register.component.html',
  styleUrls: ['./booking-register.component.css']
})
export class BookingRegisterComponent {
    bookingForm: FormGroup;
  
    constructor(private formBuilder: FormBuilder) {
      this.bookingForm = this.formBuilder.group({
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
        email: ['', [Validators.required, Validators.email]],
        checkInDate: ['', Validators.required],
        checkOutDate: ['', Validators.required]
      });
    }
    onSubmit() {
        if (this.bookingForm.valid) {
          // Process the booking data, e.g., send it to a backend server
          console.log(this.bookingForm.value);
          // Here you can make an HTTP request to your backend to save the booking
        } else {
          // Handle form validation errors
          alert('Please fill out all required fields.');
        }
      }
    }
  
    