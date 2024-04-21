import { Component, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormArray, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-booking-register',
  templateUrl: './booking-register.component.html',
  styleUrls: ['./booking-register.component.css']
})
export class BookingRegisterComponent {
  bookingForm!: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm(): void { 
    this.bookingForm = this.fb.group({
      fromDate: ['', [Validators.required]],
      toDate: ['', [Validators.required]],
      roomIds: this.fb.array([]),
      primaryVisitor: this.fb.group({
        firstName: ['', [Validators.required, Validators.maxLength(50)]], 
        middleName: ['', [Validators.required, Validators.maxLength(50)]], 
        lastName: ['', [Validators.required, Validators.maxLength(50)]], 
        email: ['', [Validators.required, Validators.email]], 
        phone: [0, [Validators.required, Validators.maxLength(10), Validators.minLength(8)]], 
        isPrimary: [1]
      }),
      partners: this.fb.array([]),
    });
  }

  addTravelPartners(): void {
    const travelPartner = this.fb.group({
      firstName: ['', [Validators.required, Validators.maxLength(50)]], 
      middleName: ['', [Validators.required, Validators.maxLength(50)]], 
      lastName: ['', [Validators.required, Validators.maxLength(50)]], 
      isPrimary: [0]
    });

    this.partners.push(travelPartner); 
  }

  get partners(): FormArray {
    return this.bookingForm.get('partners') as FormArray;
  }
	onSelected(value:string):void {
    console.log("Selected")
    console.log(value);
	}

  onSubmit() {
    if (this.bookingForm.invalid) {
      return;
    }
    console.log(this.bookingForm.value);
  }
}