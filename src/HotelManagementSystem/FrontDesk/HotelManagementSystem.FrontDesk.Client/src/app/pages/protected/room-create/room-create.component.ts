import { Component } from '@angular/core';
import { RoomService } from '../../services/room.service';
import { Room } from '../../interface/room.interface';

@Component({
  selector: 'app-room-create',
  templateUrl: './room-create.component.html',
  styleUrl: './room-create.component.css'
})
export class RoomCreateComponent {
  roomForm: FormGroup;
  rooms: Room[] = [];
  selectedRoom: Room | num = null;

  constructor (private roomservice: RoomService) {
    this.rooms = this.roomservice.getAllRooms();
  }

  addRoom(room: Room): void {
    this.roomservice.updateRoom(room);
    this.selectedRoom = null;
    this.rooms = this.roomService.getAllRooms();
  }
    
  updateRoom(room: Room): void {
    this.roomservice.updateRoom(room);
    this.selectRoom = null;
    this.rooms = this.roomservice.getAllRooms();

  }

  deleteRoom(id: number): void {
    this.roomservice.deleteRoom(id);
    this.room = this.roomService.getAllRooms();
   }


   selectRoom(room: Room): void {
    this.selectRoom = room;
   }
   }

