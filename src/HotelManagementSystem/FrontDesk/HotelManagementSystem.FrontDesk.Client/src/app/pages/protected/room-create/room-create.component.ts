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
  rooms: Room[] =[];
  selectedRoom: Room | null = null;
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
      const newRoom: Room = this.roomForm.value;
    this.roomService.addRoom(newRoom);
    this.resetForm();
    this.rooms = this.roomService.getAllAvailableRooms();
    this.showAddRoomForm = false;
    }
  

    cancelAddRoom(): void {
      this.resetForm();
      this.showAddRoomForm = false;
    }
    
    updateRoom(): void {
      if (this.selectedRoom) {
        this.roomService.updateRoom(this.selectedRoom);
        this.selectedRoom = null;
      }
    }

    cancelUpdate(): void {
      this.selectedRoom = null;
    }

  deleteRoom(roomId: number): void {
    this.roomservice.deleteRoom(roomId);
    this.rooms = this.roomservice.getAllRooms();
  }

  getAllRooms(): Room[] {
    return this.rooms;
  }
  

  filterByAvailability(available: boolean): void {
    this.rooms = this.roomservice.getAllRooms().filter(room => room.available === available);
}
}