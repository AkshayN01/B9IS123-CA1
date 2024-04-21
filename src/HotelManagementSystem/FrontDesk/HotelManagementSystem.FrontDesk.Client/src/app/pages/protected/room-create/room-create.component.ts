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
  serachType: string = '';
  searchCapacity: number | null = null;

  constructor (private roomservice: RoomService, private formBuilder: FormBuilder) {
    this.roomForm = this.formBuilder.group({
    roomNumber: [''],
      type: [''],
      capacity: [''],
      price: [''],
      available: [false]
    });
    this.rooms = this.roomService.getAllRooms();
  }

  addRoom(): void {
    const newRoom: Room = this.roomForm.value;
    this.roomService.addRoom(newRoom);
    this.resetForm();
    this.rooms = this.roomService.getAllRooms();
  }
    
  updateRoom(): void {
    if (this.selectedRoom) {
      this.roomService.updateRoom(this.selectedRoom)
    }
}

  deleteRoom(roomId: number): void {
    this.roomService.deleteRoom(roomId);
    this.rooms = this.roomService.getAllRooms();
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

  search(): void {
    this.rooms = this.roomService.getAllRooms().filter(room => {
      const typeMatch = this.searchType ? room.type.toLowerCase().includes(this.searchType.toLowerCase()) : true;
      const capacityMatch = this.searchCapacity ? room.capacity >= this.searchCapacity : true;
      return typeMatch && capacityMatch;
    });
  }

  resetSearch(): void {
    this.searchType = '';
    this.searchCapacity = null;
    this.rooms = this.roomService.getAllRooms();
  }

  private resetForm(): void {
    this.roomForm.reset({
      roomNumber: '',
      type: '',
      capacity: '',
      price: '',
      available: false
    });
  }
}
  
}