import { Component } from '@angular/core';
import { RoomService } from '../../services/room.service';
import { Room } from '../../interface/room.interface';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-room-create',
  templateUrl: './room-create.component.html',
  styleUrl: './room-create.component.css'
})
export class RoomCreateComponent {
  roomForm: FormGroup = new FormGroup({}); 
  rooms: Room[] = [];
  selectedRoom: Room | null = null;
  searchType: string = '';
  searchCapacity: number | null = null;
  newRoomNumber: string = '';
  newRoomType: string = '';
  newRoomCapacity: number | null = null;
  newRoomPrice: number | null = null;
  newRoomAvailable: boolean = false;
  showAddRoomForm: boolean = false;



  constructor (private roomservice: RoomService, private formBuilder: FormBuilder) {
    this.roomForm = this.formBuilder.group({
    roomNumber: [''],
      type: [''],
      capacity: [''],
      price: [''],
      available: [false]
    });
    this.rooms = this.roomservice.getAllRooms();
  }


  openAddRoomForm(): void {
    this.showAddRoomForm = true;

    addRoom(): void {
      const newRoom: Room = {
        roomNumber: this.newRoomNumber,
        type: this.newRoomType,
        capacity: this.newRoomCapacity,
        price: this.newRoomPrice,
        available: this.newRoomAvailable
      };

      this.roomService.addRoom(newRoom);
      this.resetAddRoomForm();
    }

      cancelAddRoom(): void {
        cancelAddRoom(): void {
          this.resetAddRoomForm();
        }
    
  updateRoom(): void {
    if (this.selectedRoom) {
      this.roomservice.updateRoom(this.selectedRoom)
    }
}

  deleteRoom(roomId: number): void {
    this.roomservice.deleteRoom(roomId);
    this.rooms = this.roomservice.getAllRooms();
  }

  getAllRooms(): Room[] {
    return this.rooms;
  }
  
  selectRoom(room: Room): void {
    this.selectedRoom = room;
    this.roomForm.patchValue(room);
  }

  cancel(): void {
    this.resetForm();
    this.selectedRoom = null;
  }

  filterByAvailability(available: boolean): void {
    this.rooms = this.roomservice.getAllRooms().filter(room => room.available === available);
}
}