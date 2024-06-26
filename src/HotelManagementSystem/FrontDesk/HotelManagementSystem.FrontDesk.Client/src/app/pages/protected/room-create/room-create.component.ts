import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validator, Validators } from '@angular/forms';

@Component({
  selector: 'app-room-create',
  templateUrl: './room-create.component.html',
  styleUrl: './room-create.component.css'
})
export class RoomCreateComponent {
  roomForm: FormGroup;

  constructor (private FormBuilder: FormBuilder) {
    this.roomForm = this.FormBuilder.group ({
      roomNumer: ['', Validators.required],
      type: ['', Validators.required],
      price: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.roomForm.valid) {
      console.log(this.roomForm.value);
    } else {
    }
  }
}