import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validator, Validators } from '@angular/forms';
import { RoomService } from '../../../services/room.service';

@Component({
  selector: 'app-room-create',
  templateUrl: './room-create.component.html',
  styleUrl: './room-create.component.css'
})
export class RoomCreateComponent {
  roomForm: FormGroup;
  rooms: Room[] = [];
  selectedRoom: Room | numm = null;

  constructor (private roomservice: RoomService) {
    this.roomForm = this.FormBuilder.group ({
      roomNumer: ['', Validators.required],
      type: ['', Validateors.required],
      price: ['', Validators.required]]
    });
  }

  onSubmit() {
    if (this.roomForm.valid) {
      console.log(this.roomForm.value);
    } else {
    }
  }
}
