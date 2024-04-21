import { Component } from '@angular/core';
import { RoomService } from '../../services/room.service';
import { Room } from '../../interface/room.interface';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-room-create',
  templateUrl: './room-create.component.html',
  styleUrl: './room-create.component.css'
})
export class RoomCreateComponent {
  roomForm: FormGroup = new FormGroup({}); 
  rooms: Room[] = [];
  selectedRoom: Room | null = null;

  constructor (private roomservice: RoomService) {
    this.rooms = this.roomservice.getAllRooms();
  }

  addRoom(room: Room): void {
    this.roomservice.updateRoom(room);
    this.selectedRoom = null;
    this.rooms = this.roomservice.getAllRooms();
  }
    
  updateRoom(room: Room): void {
    const index = this.rooms.findIndex(r => r.id === room.id);
    if (index !== -1) {
      this.rooms[index] = room;
  }
}

  deleteRoom(roomId: number): void {
    this.rooms = this.rooms.filter(room => room.id !== roomId);
  }

  getAllRooms(): Room[] {
    return this.rooms;
  }
  
  selectRoom(room: Room): void {
    this.selectedRoom = room;
  }

  cancel(): void {
    console.log('Cancel button clicked');
  }
}