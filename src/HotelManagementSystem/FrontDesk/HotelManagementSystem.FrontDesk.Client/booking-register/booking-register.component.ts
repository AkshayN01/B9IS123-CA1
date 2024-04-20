import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-booking-register',
  templateUrl: './booking-register.component.html',
  styleUrls: ['./booking-register.component.css']
})
export class BookingRegisterComponent {
  formData = {
    firstname: '',
    lastname:'',
    email: '',
    phone: '',
    checkin: '',
    checkout: '',
    roomtype: ''
  };
  

  persons: Person[] = []; // Array to store information about each person

  addPerson() {
    this.persons.push({ name: '', email: '', phone: '' });
  }

  removePerson(index: number) {
    this.persons.splice(index, 1);
  }

  submitForm() {
    // Handle form submission logic here
    console.log('Form Data:', this.formData);
    console.log('Persons:', this.persons);
    this.clearFormData();
  }

  clearFormData() {
    this.formData = {
      firstname: '',
      lastname:'',
      email: '',
      phone: '',
      checkin: '',
      checkout: '',
      roomtype: ''
    };
    this.persons = [];
  }
}